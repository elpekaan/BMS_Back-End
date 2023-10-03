// Kimlik doğrulama servisi sınıfı
using Business.Models.Request.Functional;
using Business.Models.Response;
using Business.Services.Interface;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Business.Utilities.Validation.Interface;
using Core.Constants;
using Core.Results;
using Core.Utilities;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Token = Core.Constants.Token;

namespace Business.Services
{
    // AuthService sınıfı, IAuthService arayüzünü uygular
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimHelper _claimHelper;
        private readonly IMapperHelper _mapperHelper;
        private readonly IValidationHelper _validationHelper;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IHashingHelper _hashingHelper;

        // Constructor metodu, bağımlılıkları enjekte eder
        public AuthService(IUnitOfWork unitOfWork,
            IClaimHelper claimHelper,
            IMapperHelper mapperHelper,
            IValidationHelper validationHelper,
            IJwtTokenHelper jwtTokenHelper,
            IHashingHelper hashingHelper)
        {
            _unitOfWork = unitOfWork;
            _claimHelper = claimHelper;
            _mapperHelper = mapperHelper;
            _validationHelper = validationHelper;
            _jwtTokenHelper = jwtTokenHelper;
            _hashingHelper = hashingHelper;
        }

        // Kullanıcı kaydı yapma metodu
        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> Register(RegisterDto registerDto)
        {
            // Gelen DTO'nun doğruluğunu kontrol etme
            var validationError = await _validationHelper.ValidateAsync(registerDto);

            if (!string.IsNullOrEmpty(validationError))
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: validationError,
                    status: ResultStatus.Invalid);

            // Kullanıcı adının zaten alınıp alınmadığını kontrol etme
            if (await _unitOfWork.Users.FirstOrDefaultAsync(u => u.UserName == registerDto.UserName) != null)
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.UserNameAlreadyTaken,
                    status: ResultStatus.Invalid);

            // E-posta adresinin zaten alınıp alınmadığını kontrol etme
            if (await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email) != null)
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.EmailAlreadyTaken,
                    status: ResultStatus.Invalid);

            // DTO'dan User varlığına eşleme yapma
            var user = _mapperHelper.Map<User>(registerDto);

            // Şifreyi hashleme
            _hashingHelper.CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Kullanıcıyı veritabanına ekleme
            await _unitOfWork.Users.AddAsync(user);

            // Değişiklikleri kaydetme
            await _unitOfWork.CommitAsync();

            // Yeni bir refresh token oluşturma
            var refreshToken = new UserToken(user.Id, DateTime.UtcNow.Date.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            // Refresh token'ı veritabanına ekleme
            await _unitOfWork.UserTokens.AddAsync(refreshToken);

            // Access token oluşturma
            var token = _jwtTokenHelper.CreateAccessToken(user, refreshToken.Token);

            // Değişiklikleri kaydetme
            await _unitOfWork.CommitAsync();

            // Sonuçları döndürme
            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: token, status: ResultStatus.Ok);
        }

        // Kullanıcı girişi yapma metodu
        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> Login(LoginDto loginDto)
        {
            // Gelen DTO'nun doğruluğunu kontrol etme
            var validationError = await _validationHelper.ValidateAsync(loginDto);

            if (!string.IsNullOrEmpty(validationError))
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: validationError, status: ResultStatus.Invalid);
            }

            // Kullanıcı adına göre kullanıcıyı bulma
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            // Kullanıcı yoksa veya şifre doğrulanamazsa hata döndürme
            if (user == null || !_hashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.UserNameOrPasswordWrong, status: ResultStatus.Invalid);
            }

            // Yeni bir refresh token oluşturma
            var refreshToken = new UserToken(user.Id, DateTime.UtcNow.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            // Access token oluşturma
            var token = _jwtTokenHelper.CreateAccessToken(user, refreshToken.Token);

            // Refresh token'ı veritabanına ekleme
            await _unitOfWork.UserTokens.AddAsync(refreshToken);

            // Değişiklikleri kaydetme
            await _unitOfWork.CommitAsync();

            // Sonuçları döndürme
            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: token, status: ResultStatus.Ok);
        }

        // Kullanıcı profili bilgilerini getirme metodu
        public async Task<DataResult<UserProfileDto>> GetUserProfileInfo()
        {
            // Token içindeki kullanıcı kimliğini alma
            var userId = _claimHelper.GetUserId();

            // Kullanıcıyı kimliğine göre bulma
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Kullanıcı profili DTO'ya eşleme yapma
            var profileDto = _mapperHelper.Map<UserProfileDto>(user);

            // Sonuçları döndürme
            return new DataResult<UserProfileDto>(data: profileDto, status: ResultStatus.Ok);
        }

        // Refresh token kullanarak yeni bir access token oluşturma metodu
        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> RefreshToken(string refreshToken)
        {
            // Veritabanında refresh token'ı bulma
            var token = await _unitOfWork.UserTokens.GetWithPropertiesAsync(refreshToken);

            // Token veya kullanıcı yoksa hata döndürme
            if (token?.User == null)
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(status: ResultStatus.Invalid);
            }

            // Yeni bir refresh token oluşturma
            var newRefreshToken = new UserToken(token.User.Id, DateTime.UtcNow.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            // Yeni access token oluşturma
            var jwtToken = _jwtTokenHelper.CreateAccessToken(token.User, newRefreshToken.Token);

            // Mevcut refresh token'ı silme
            _unitOfWork.UserTokens.Remove(token);

            // Yeni refresh token'ı veritabanına ekleme
            await _unitOfWork.UserTokens.AddAsync(newRefreshToken);

            // Değişiklikleri kaydetme
            await _unitOfWork.CommitAsync();

            // Sonuçları döndürme
            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: jwtToken, status: ResultStatus.Ok);
        }
    }
}

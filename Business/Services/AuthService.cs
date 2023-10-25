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
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimHelper _claimHelper;
        private readonly IMapperHelper _mapperHelper;
        private readonly IValidationHelper _validationHelper;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IHashingHelper _hashingHelper;

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

        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> Register(RegisterDto registerDto)
        {
            var validationError = await _validationHelper.ValidateAsync(registerDto);

            if (!string.IsNullOrEmpty(validationError))
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: validationError,
                    status: ResultStatus.Invalid);

            if (await _unitOfWork.Users.FirstOrDefaultAsync(u => u.UserName == registerDto.UserName) != null)
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.UserNameAlreadyTaken,
                    status: ResultStatus.Invalid);

            if (await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email) != null)
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.EmailAlreadyTaken,
                    status: ResultStatus.Invalid);

            var user = _mapperHelper.Map<User>(registerDto);

            _hashingHelper.CreatePasswordHash(registerDto.Password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.CommitAsync();

            var refreshToken = new UserToken(user.Id, DateTime.UtcNow.Date.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            await _unitOfWork.UserTokens.AddAsync(refreshToken);

            var token = _jwtTokenHelper.CreateAccessToken(user, refreshToken.Token);

            await _unitOfWork.CommitAsync();

            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: token, status: ResultStatus.Ok);
        }

        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> Login(LoginDto loginDto)
        {
            var validationError = await _validationHelper.ValidateAsync(loginDto);

            if (!string.IsNullOrEmpty(validationError))
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: validationError, status: ResultStatus.Invalid);
            }

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null || !_hashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(message: Messages.UserNameOrPasswordWrong, status: ResultStatus.Invalid);
            }

            var refreshToken = new UserToken(user.Id, DateTime.UtcNow.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            var token = _jwtTokenHelper.CreateAccessToken(user, refreshToken.Token);

            await _unitOfWork.UserTokens.AddAsync(refreshToken);

            await _unitOfWork.CommitAsync();

            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: token, status: ResultStatus.Ok);
        }

        public async Task<DataResult<UserProfileDto>> GetUserProfileInfo()
        {
            var userId = _claimHelper.GetUserId();

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var profileDto = _mapperHelper.Map<UserProfileDto>(user);

            return new DataResult<UserProfileDto>(data: profileDto, status: ResultStatus.Ok);
        }

        public async Task<DataResult<Utilities.Security.Auth.Jwt.Token>> RefreshToken(string refreshToken)
        {
            var token = await _unitOfWork.UserTokens.GetWithPropertiesAsync(refreshToken);

            if (token?.User == null)
            {
                return new DataResult<Utilities.Security.Auth.Jwt.Token>(status: ResultStatus.Invalid);
            }

            var newRefreshToken = new UserToken(token.User.Id, DateTime.UtcNow.ToTimeZone().AddDays(Token.RefreshTokenValidUntilDays));

            var jwtToken = _jwtTokenHelper.CreateAccessToken(token.User, newRefreshToken.Token);

            _unitOfWork.UserTokens.Remove(token);

            await _unitOfWork.UserTokens.AddAsync(newRefreshToken);

            await _unitOfWork.CommitAsync();

            return new DataResult<Utilities.Security.Auth.Jwt.Token>(data: jwtToken, status: ResultStatus.Ok);
        }
    }
}

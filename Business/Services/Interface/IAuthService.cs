using Business.Models.Request.Functional;
using Business.Models.Response;
using Business.Utilities.Security.Auth.Jwt;
using Core.Results;

namespace Business.Services.Interface;

// Kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini tanımlayan IAuthService arayüzü
public interface IAuthService
{
    // Kullanıcı kaydı işlemini gerçekleştirir
    Task<DataResult<Token>> Register(RegisterDto registerDto);

    // Kullanıcı girişi işlemini gerçekleştirir
    Task<DataResult<Token>> Login(LoginDto loginDto);

    // Kullanıcının profil bilgilerini getirir
    Task<DataResult<UserProfileDto>> GetUserProfileInfo();

    // Yeniden token almak için kullanılan işlem
    Task<DataResult<Token>> RefreshToken(string refreshToken);
}

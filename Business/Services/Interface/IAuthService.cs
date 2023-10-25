using Business.Models.Request.Functional;
using Business.Models.Response;
using Business.Utilities.Security.Auth.Jwt;
using Core.Results;

namespace Business.Services.Interface;

public interface IAuthService
{
    Task<DataResult<Token>> Register(RegisterDto registerDto);

    Task<DataResult<Token>> Login(LoginDto loginDto);

    Task<DataResult<UserProfileDto>> GetUserProfileInfo();

    Task<DataResult<Token>> RefreshToken(string refreshToken);
}

using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Security.Auth.Jwt.Interface;

// JWT token oluşturmayı sağlayan arayüz
public interface IJwtTokenHelper
{
    // Verilen kullanıcı ve yeniden token için JWT oluşturur
    Token CreateAccessToken(User user, string refreshToken);
}

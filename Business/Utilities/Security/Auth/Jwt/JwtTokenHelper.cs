using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Core.Utilities;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Utilities.Security.Auth.Jwt;

// JWT (Json Web Token) oluşturma işlemlerini gerçekleştiren yardımcı sınıf
public class JwtTokenHelper : IJwtTokenHelper
{
    private readonly IConfiguration _configuration;

    // Yapılandırma ayarlarını enjekte eden bir constructor
    public JwtTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Verilen kullanıcı ve yeniden token ile birlikte erişim token'ını oluşturur
    public Token CreateAccessToken(User user, string refreshToken)
    {
        // JWT'nin şifreleme anahtarını oluşturur
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));

        // JWT'nin imza bilgilerini oluşturur
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Token'ın geçerlilik süresini ve diğer bilgilerini ayarlar
        var expirationDate = DateTime.UtcNow.ToTimeZone().AddHours(1);

        // JWT Security Token'ını oluşturur
        var securityToken = new JwtSecurityToken(
            audience: _configuration["TokenOptions:Audience"],
            issuer: _configuration["TokenOptions:Issuer"],
            claims: SetClaims(user),
            expires: expirationDate,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
        );

        // JWT Security Token'ını ele alacak bir handler oluşturur
        var tokenHandler = new JwtSecurityTokenHandler();

        // Oluşturulan JWT'yi yazarak, bir Token nesnesi oluşturur
        var tokenInstance = new Token(tokenHandler.WriteToken(securityToken), expirationDate, refreshToken);

        return tokenInstance;
    }

    // JWT için talep bilgilerini ayarlar
    private static IEnumerable<Claim> SetClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Actor, user.UserType.ToString())
        };

        return claims;
    }
}

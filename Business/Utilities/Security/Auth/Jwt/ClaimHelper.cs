// JWT (Json Web Token) taleplerine erişim sağlayan yardımcı sınıf
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

// JWT taleplerine erişim sağlayan yardımcı sınıf
public class ClaimHelper : IClaimHelper
{
    // HttpContext'tan gelen taleplerin içindeki iddiaları tutan liste
    private readonly IEnumerable<Claim> _claims;

    // IHttpContextAccessor ile gelen HttpContext'tan kullanıcı taleplerini alır
    public ClaimHelper(IHttpContextAccessor httpContextAccessor)
    {
        // HttpContext'tan gelen kullanıcı taleplerini alır
        // Eğer HttpContext null ise boş bir liste oluşturur
        _claims = httpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>();
    }

    // Kullanıcı ID'sini alır
    public int? GetUserId()
    {
        // Kullanıcı ID'sini almak için JWT'deki NameIdentifier tipindeki talepten değeri çıkarır
        // Eğer başarılı bir şekilde çıkarılırsa, bu değeri integer'a çevirip döndürür
        // Eğer çıkarma veya çevirme işlemleri başarısız olursa null döndürür
        if (int.TryParse(_claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var id))
        {
            return id;
        }

        return null;
    }

    // Kullanıcı tipini (UserType) alır
    public UserType? GetUserType()
    {
        // Kullanıcı tipini almak için JWT'deki Actor tipindeki talepten değeri çıkarır
        // Eğer başarılı bir şekilde çıkarılırsa, bu değeri UserType enum'ına çevirip döndürür
        // Eğer çıkarma veya çevirme işlemleri başarısız olursa null döndürür
        if (Enum.TryParse<UserType>(_claims.FirstOrDefault(c => c.Type == ClaimTypes.Actor)?.Value, out var userType))
        {
            return userType;
        }

        return null;
    }

    // Belirli bir talep tipine göre talep değerini alır
    public string? GetClaimByType(string claimType)
    {
        // Verilen talep tipine göre talep değerini alır, eğer talep bulunamazsa null döndürür
        return _claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    }
}


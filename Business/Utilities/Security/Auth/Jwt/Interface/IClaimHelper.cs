// JSON Web Token (JWT) iddialarını almak için kullanılan arayüz
using Infrastructure.Data.Postgres.Entities;

public interface IClaimHelper
{
    // Kullanıcı kimliğini alır
    int? GetUserId();

    // Kullanıcı tipini alır
    UserType? GetUserType();

    // Belirli bir iddiayı tipine göre alır
    string? GetClaimByType(string claimType);
}

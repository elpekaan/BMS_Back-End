using Core.Utilities;  // DateTimeUtilities sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Entities;  // User sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DbContext ve EntityTypeBuilder kullanmak için gerekli isim alanları
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı
using System.Text;  // Encoding sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // User sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // User sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // User sınıfının kimlik alanını belirleyen özelliği
            builder.HasKey(x => x.Id);

            // Email özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Email).IsRequired();

            // Email özelliği üzerinde benzersiz bir indeks oluşturan kısım
            builder.HasIndex(x => x.Email).IsUnique();

            // UserName özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.UserName).IsRequired();

            // UserName özelliği üzerinde benzersiz bir indeks oluşturan kısım
            builder.HasIndex(x => x.UserName).IsUnique();

            // UserType özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.UserType).IsRequired();

            // Şifreleme için kullanılacak salt ve hash değerlerini oluşturuyoruz
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123123123"));

                // Veritabanına örnek kullanıcı verilerini ekliyoruz
                builder.HasData(new User
                {
                    Id = 1,
                    Tc_no = "32324324234234",
                    FullName = "Bülent Karanfil",
                    UserName = "bulent123",
                    Email = "bg@gmail.com",
                    Phone = "324763282348237",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    UserType = UserType.Admin,  // Enum'dan değer atanıyor
                    CreatedAt = DateTime.UtcNow.ToTimeZone(),
                    UpdatedAt = DateTime.UtcNow.ToTimeZone(),
                    IsDeleted = false
                },
                new User
                {
                    Id = 2,
                    Tc_no = "45756865745654",
                    FullName = "Kan kaan",
                    UserName = "kan123",
                    Email = "kaam@gmail.com",
                    Phone = "324763282348237",
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    UserType = UserType.Admin,  // Enum'dan değer atanıyor
                    CreatedAt = DateTime.UtcNow.ToTimeZone(),
                    UpdatedAt = DateTime.UtcNow.ToTimeZone(),
                    IsDeleted = false
                });
            }
        }
    }
}

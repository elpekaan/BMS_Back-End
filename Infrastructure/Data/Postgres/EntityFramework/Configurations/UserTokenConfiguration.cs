using Infrastructure.Data.Postgres.Entities;  // UserToken sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // EntityTypeBuilder ve DbContext sınıflarını kullanmak için gerekli isim alanları
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // UserToken sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        // UserToken sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            // UserToken sınıfının Token özelliğini kimlik alanı olarak belirleyen kısım
            builder.HasKey(x => x.Token);

            // UserToken sınıfının UserId özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.UserId).IsRequired();

            // UserToken sınıfının ValidUntil özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.ValidUntil).IsRequired();
        }
    }
}

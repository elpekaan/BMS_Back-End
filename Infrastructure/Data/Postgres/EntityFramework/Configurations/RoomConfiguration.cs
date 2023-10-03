using Infrastructure.Data.Postgres.Entities;  // Room sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DeleteBehavior kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // Room sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        // Room sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Room sınıfının kimlik alanını belirleyen özelliği
            builder.HasKey(x => x.Id);

            // Room_Name özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Room_Name).IsRequired();

            // Room sınıfının User ilişkisini tanımlayan kısım
            builder.HasOne(x => x.User)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // User silindiğinde bağlı odalar da silinir
        }
    }
}

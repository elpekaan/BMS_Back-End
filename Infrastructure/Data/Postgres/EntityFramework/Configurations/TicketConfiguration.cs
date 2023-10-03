using Infrastructure.Data.Postgres.Entities;  // Ticket sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DeleteBehavior kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // Ticket sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        // Ticket sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // Ticket sınıfının kimlik alanını belirleyen özelliği
            builder.HasKey(x => x.Id);

            // Ticket_Content özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Ticket_Content).IsRequired();

            // Ticket_Status özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Ticket_Status).IsRequired();

            // Ticket sınıfının User ilişkisini tanımlayan kısım
            builder.HasOne(x => x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // User silindiğinde bağlı ticket'lar da silinir

            // Ticket sınıfının Room ilişkisini tanımlayan kısım
            builder.HasOne(x => x.Room)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Cascade);  // Room silindiğinde bağlı ticket'lar da silinir
        }
    }
}

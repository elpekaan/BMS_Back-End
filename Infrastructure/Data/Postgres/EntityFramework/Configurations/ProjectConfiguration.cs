using Infrastructure.Data.Postgres.Entities;  // Project sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DeleteBehavior kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // Project sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        // Project sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Project sınıfının kimlik alanını belirleyen özelliği
            builder.HasKey(x => x.Id);

            // Project_Title özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Project_Title).IsRequired();

            // Project_Description özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Project_Description).IsRequired();

            // Project_DeadLine özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Project_DeadLine).IsRequired();

            // Project_Status özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.Project_Status).IsRequired();

            // Project sınıfının User ilişkisini tanımlayan kısım
            builder.HasOne(x => x.User)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // User silindiğinde Project'ler silinmez

            // Project sınıfının Room ilişkisini tanımlayan kısım
            builder.HasOne(x => x.Room)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);  // Room silindiğinde Project'ler silinmez
        }
    }
}

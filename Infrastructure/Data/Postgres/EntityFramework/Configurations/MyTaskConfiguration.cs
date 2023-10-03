using Infrastructure.Data.Postgres.Entities;  // MyTask sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore.Metadata.Builders;  // EntityTypeBuilder kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DeleteBehavior kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    // MyTask sınıfının veritabanı konfigürasyonunu sağlayan sınıf
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTask>
    {
        // MyTask sınıfının EntityTypeBuilder üzerinden konfigürasyonunu yapma metodu
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            // MyTask sınıfının kimlik alanını belirleyen özelliği
            builder.HasKey(x => x.Id);

            // MyTask_Title özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.MyTask_Title).IsRequired();

            // MyTask_Description özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.MyTask_Description).IsRequired();

            // MyTask_DeadLine özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.MyTask_DeadLine).IsRequired();

            // MyTask_Status özelliğinin boş geçilemeyeceğini belirleyen kısıt
            builder.Property(x => x.MyTask_Status).IsRequired();

            // MyTask sınıfının User ilişkisini tanımlayan kısım
            builder.HasOne(x => x.User)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // User silindiğinde MyTask'lar silinmez

            // MyTask sınıfının User ilişkisini tanımlayan kısım
            builder.HasOne(x => x.User)
                .WithMany(x => x.MyTasks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);  // User silindiğinde MyTask'lar da silinir
        }
    }
}

using Core.Utilities;  // DateTimeUtilities sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Entities.Base.Interface;  // IEntity arayüzünü kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Entities.Base
{
    // Temel varlık (entity) sınıfı
    public abstract class Entity<T> : IEntity
    {
        // Varlığın kimlik alanını temsil eden özellik
        public T Id { get; set; } = default!;

        // Varlığın oluşturulma tarihini temsil eden özellik
        public DateTime CreatedAt { get; set; }

        // Varlığın güncellenme tarihini temsil eden, isteğe bağlı özellik
        public DateTime? UpdatedAt { get; set; }

        // Varlığın silinip silinmediğini temsil eden özellik
        public bool IsDeleted { get; set; }

        // Entity sınıfının constructor metodu
        protected Entity()
        {
            // Oluşturulan tarihi, geçerli zaman dilimine çeviren ve CreatedAt özelliğine atayan blok
            CreatedAt = DateTime.UtcNow.ToTimeZone();

            // IsDeleted özelliğini false olarak ayarlayan blok
            IsDeleted = false;
        }
    }
}

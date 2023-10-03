using System;  // DateTime sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Entities.Base.Interface
{
    // Varlık (entity) sınıflarının uyması gereken arayüz
    public interface IEntity
    {
        // Varlığın oluşturulma tarihini temsil eden özellik
        public DateTime CreatedAt { get; set; }

        // Varlığın güncellenme tarihini temsil eden, isteğe bağlı özellik
        public DateTime? UpdatedAt { get; set; }

        // Varlığın silinip silinmediğini temsil eden özellik
        public bool IsDeleted { get; set; }
    }
}

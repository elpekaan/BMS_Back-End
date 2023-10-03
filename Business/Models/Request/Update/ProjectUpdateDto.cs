// Business katmanındaki Update talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;  // Projeye ait durumları içeren enum'u kullanmak için gerekli isim alanı
using System;  // DateTime sınıfını kullanmak için gerekli isim alanı

namespace Business.Models.Request.Update
{
    // Proje güncelleme işlemi için kullanılacak DTO sınıfı
    public class ProjectUpdateDto
    {
        // Proje başlığını temsil eden özellik
        public string Project_Title { get; set; }

        // Proje açıklamasını temsil eden özellik
        public string Project_Description { get; set; }

        // Projenin bitiş tarihini temsil eden özellik
        public DateTime Project_DeadLine { get; set; }

        // Projenin durumunu temsil eden özellik
        public ProjectStatus Project_Status { get; set; }

        // Projenin atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Projenin atanmış olduğu oda bilgisini temsil eden özellik
        public int RoomId { get; set; }
    }
}

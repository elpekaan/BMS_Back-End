// Gerekli isim alanlarını ekliyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;

// Business katmanındaki Create talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
namespace Business.Models.Request.Create
{
    public class ProjectCreateDto
    {
        // Proje başlığını temsil eden özellik
        public string Project_Title { get; set; }

        // Proje açıklamasını temsil eden özellik
        public string Project_Description { get; set; }

        // Projenin bitiş tarihini temsil eden özellik
        public DateTime Project_DeadLine { get; set; }

        // Proje durumunu temsil eden özellik
        public ProjectStatus Project_Status { get; set; }

        // Proje ile ilişkilendirilmiş kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Proje ile ilişkilendirilmiş odağın kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; }
    }
}

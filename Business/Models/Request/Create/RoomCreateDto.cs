// Gerekli isim alanlarını ekliyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;

// Business katmanındaki Create talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
namespace Business.Models.Request.Create
{
    public class RoomCreateDto
    {
        // Oda adını temsil eden özellik
        public string Room_Name { get; set; }

        // Odayı oluşturan kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }
    }
}

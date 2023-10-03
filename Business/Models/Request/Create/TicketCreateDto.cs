// Gerekli isim alanlarını ekliyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;

// Business katmanındaki Create talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
namespace Business.Models.Request.Create
{
    public class TicketCreateDto
    {
        // Bilet içeriğini temsil eden özellik
        public string Ticket_Content { get; set; }

        // Biletin ait olduğu oda id'sini temsil eden özellik
        public int RoomId { get; set; }

        // Bileti oluşturan kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Biletin durumunu temsil eden özellik
        public TicketStatus Ticket_Status { get; set; }
    }
}

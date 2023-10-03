// Business katmanındaki Update talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;  // Biletin ait olduğu odayı temsil eden Room sınıfını ve biletin durumunu temsil eden TicketStatus enumunu kullanmak için gerekli isim alanları

namespace Business.Models.Request.Update
{
    // Bilet güncelleme işlemi için kullanılacak DTO sınıfı
    public class TicketUpdateDto
    {
        // Bilet içeriğini temsil eden özellik
        public string Ticket_Content { get; set; }

        // Biletin ait olduğu oda için kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; }

        // Bileti oluşturan kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Biletin durumunu temsil eden özellik
        public TicketStatus Ticket_Status { get; set; }
    }
}

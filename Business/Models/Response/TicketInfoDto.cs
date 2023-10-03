// Business katmanındaki Ticket varlıklarının bilgilerini döndürmek için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    // Ticket varlıklarının bilgilerini döndürmek için kullanılacak DTO sınıfı
    public class TicketInfoDto
    {
        // Ticket varlığının kimlik bilgisini temsil eden özellik
        public int Id { get; set; } = default!;

        // Ticket varlığının içeriğini temsil eden özellik
        public string Ticket_Content { get; set; } = default!;

        // Ticket varlığının ait olduğu oda kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; } = default!;

        // Ticket varlığının sahibi kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; } = default!;

        // Ticket varlığının durumunu temsil eden özellik
        public TicketStatus Ticket_Status { get; set; }

        // Ticket varlığının sahibi kullanıcının profil bilgilerini temsil eden özellik
        public UserProfileDto User { get; set; }

        // Ticket varlığının ait olduğu oda bilgilerini temsil eden özellik
        public RoomInfoDto Room { get; set; }
    }
}

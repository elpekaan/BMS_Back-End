using Infrastructure.Data.Postgres.Entities.Base;  // Temel varlık sınıfını kullanmak için gerekli isim alanı
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    // Ticket sınıfı, temel varlık sınıfından türer ve int türündeki bir kimlik alanına sahiptir.
    public class Ticket : Entity<int>
    {
        // Ticket'ın içeriğini temsil eden özellik
        public string Ticket_Content { get; set; }

        // Ticket'a atanmış oda (Room) nun kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; }

        // Ticket'ı oluşturan kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Ticket'ın durumunu temsil eden özellik, NotStarted, InProgress, Completed olabilir
        public TicketStatus Ticket_Status { get; set; }

        // Ticket'a atanmış odayı temsil eden özellik
        public Room Room { get; set; }

        // Ticket'ı oluşturan kullanıcıyı temsil eden özellik
        public User User { get; set; }
    }

    // Ticket'ın durumunu belirten enum (numaralandırma) türü
    public enum TicketStatus
    {
        NotStarted,   // Ticket başlatılmamış durumda
        InProgress,   // Ticket devam ediyor
        Completed     // Ticket tamamlanmış durumda
    }
}

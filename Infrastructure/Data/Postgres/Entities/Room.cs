using Infrastructure.Data.Postgres.Entities.Base;  // Temel varlık sınıfını kullanmak için gerekli isim alanı
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    // Room sınıfı, temel varlık sınıfından türer ve int türündeki bir kimlik alanına sahiptir.
    public class Room : Entity<int>
    {
        // Oda (Room) adını temsil eden özellik
        public string Room_Name { get; set; }

        // Odanın sahibinin kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Odaya atanmış projeleri temsil eden liste özelliği
        public List<Project> Projects { get; set; }

        // Odaya atanmış ticket'ları temsil eden liste özelliği
        public List<Ticket> Tickets { get; set; }

        // Oda sahibini temsil eden özellik
        public User User { get; set; }
    }
}

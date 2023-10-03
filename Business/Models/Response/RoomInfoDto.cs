// Business katmanındaki Room varlıklarının bilgilerini döndürmek için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    // Room varlıklarının bilgilerini döndürmek için kullanılacak DTO sınıfı
    public class RoomInfoDto
    {
        // Room varlığının kimlik bilgisini temsil eden özellik
        public int Id { get; set; } = default!;

        // Room varlığının adını temsil eden özellik
        public string Room_Name { get; set; } = default!;

        // Room varlığının sahibi kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; } = default!;

        // Room varlığının içindeki projeleri temsil eden liste özelliği
        public List<Project> Projects { get; set; } = default!;

        // Room varlığının içindeki ticket'ları temsil eden liste özelliği
        public List<Ticket> Tickets { get; set; } = default!;

        // Room varlığının sahibi kullanıcının profil bilgilerini temsil eden özellik
        public UserProfileDto User { get; set; }
    }
}

// Business katmanındaki Project varlıklarının bilgilerini döndürmek için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    // Project varlıklarının bilgilerini döndürmek için kullanılacak DTO sınıfı
    public class ProjectInfoDto
    {
        // Project varlığının kimlik bilgisini temsil eden özellik
        public int Id { get; set; } = default!;

        // Project varlığının başlığını temsil eden özellik
        public string Project_Title { get; set; } = default!;

        // Project varlığının açıklamasını temsil eden özellik
        public string Project_Description { get; set; } = default!;

        // Project varlığının bitiş tarihini temsil eden özellik
        public DateTime Project_DeadLine { get; set; } = default!;

        // Project varlığının durumunu temsil eden özellik
        public ProjectStatus Project_Status { get; set; }

        // Project varlığının sahibi kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; } = default!;

        // Project varlığının atanmış olduğu oda varlığının kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; } = default!;

        // Project varlığının sahibi kullanıcının profil bilgilerini temsil eden özellik
        public UserProfileDto User { get; set; }

        // Project varlığının atanmış olduğu oda varlığının bilgilerini temsil eden özellik
        public RoomInfoDto Room { get; set; }
    }
}

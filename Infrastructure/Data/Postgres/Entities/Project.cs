using Infrastructure.Data.Postgres.Entities.Base;  // Temel varlık sınıfını kullanmak için gerekli isim alanı
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    // Project sınıfı, temel varlık sınıfından türer ve int türündeki bir kimlik alanına sahiptir.
    public class Project : Entity<int>
    {
        // Projenin başlığını temsil eden özellik
        public string Project_Title { get; set; }

        // Projenin açıklamasını temsil eden özellik
        public string Project_Description { get; set; }

        // Projenin bitiş tarihini temsil eden özellik
        public DateTime Project_DeadLine { get; set; }

        // Projenin durumunu temsil eden özellik, NotStarted, InProgress, Completed olabilir
        public ProjectStatus Project_Status { get; set; }

        // Projenin atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Projenin atanmış olduğu oda (Room) nun kimlik bilgisini temsil eden özellik
        public int RoomId { get; set; }

        // Projenin atanmış olduğu kullanıcıyı temsil eden özellik
        public User User { get; set; }

        // Projenin atanmış olduğu odayı temsil eden özellik
        public Room Room { get; set; }
    }

    // Projenin durumunu belirten enum (numaralandırma) türü
    public enum ProjectStatus
    {
        NotStarted,   // Proje başlatılmamış durumda
        InProgress,   // Proje devam ediyor
        Completed     // Proje tamamlanmış durumda
    }
}

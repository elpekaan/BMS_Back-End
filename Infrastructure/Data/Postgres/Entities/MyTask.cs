using Infrastructure.Data.Postgres.Entities.Base;  // Temel varlık sınıfını kullanmak için gerekli isim alanı
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    // MyTask sınıfı, temel varlık sınıfından türer ve int türündeki bir kimlik alanına sahiptir.
    public class MyTask : Entity<int>
    {
        // Görevin başlığını temsil eden özellik
        public string MyTask_Title { get; set; }

        // Görevin açıklamasını temsil eden özellik
        public string MyTask_Description { get; set; }

        // Görevin bitiş tarihini temsil eden özellik
        public DateTime MyTask_DeadLine { get; set; }

        // Görevin durumunu temsil eden özellik, NotStarted, InProgress, Completed olabilir
        public MyTaskStatus MyTask_Status { get; set; }

        // Görevin atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }

        // Görevin atanmış olduğu kullanıcıyı temsil eden özellik
        public User User { get; set; }
    }

    // Görevin durumunu belirten enum (numaralandırma) türü
    public enum MyTaskStatus
    {
        NotStarted,   // Görev başlatılmamış durumda
        InProgress,   // Görev devam ediyor
        Completed     // Görev tamamlanmış durumda
    }
}

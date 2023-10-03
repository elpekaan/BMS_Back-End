// Business katmanındaki Update talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Request.Update
{
    // Görev güncelleme işlemi için kullanılacak DTO sınıfı
    public class MyTaskUpdateDto
    {
        // Görev başlığını temsil eden özellik
        public string MyTask_Title { get; set; }

        // Görev açıklamasını temsil eden özellik
        public string MyTask_Description { get; set; }

        // Görevin bitiş tarihini temsil eden özellik
        public DateTime MyTask_DeadLine { get; set; }

        // Görevin durumunu temsil eden özellik
        public MyTaskStatus MyTask_Status { get; set; }

        // Görevin atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }
    }
}

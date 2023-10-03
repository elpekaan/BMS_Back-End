// Business katmanındaki MyTask varlıklarının bilgilerini döndürmek için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using System;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Response
{
    // MyTask varlıklarının bilgilerini döndürmek için kullanılacak DTO sınıfı
    public class MyTaskInfoDto
    {
        // MyTask varlığının kimlik bilgisini temsil eden özellik
        public int Id { get; set; } = default!;

        // MyTask varlığının başlığını temsil eden özellik
        public string MyTask_Title { get; set; } = default!;

        // MyTask varlığının açıklamasını temsil eden özellik
        public string MyTask_Description { get; set; } = default!;

        // MyTask varlığının bitiş tarihini temsil eden özellik
        public DateTime MyTask_DeadLine { get; set; } = default!;

        // MyTask varlığının durumunu temsil eden özellik
        public MyTaskStatus MyTask_Status { get; set; }

        // MyTask varlığının atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; } = default!;

        // MyTask varlığının atanmış olduğu kullanıcının profil bilgilerini temsil eden özellik
        public UserProfileDto User { get; set; }
    }
}

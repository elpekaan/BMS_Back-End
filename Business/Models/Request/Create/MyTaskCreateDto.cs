using System;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Request.Create
{
    // MyTask oluşturma işlemi için kullanılan veri transfer nesnesi (DTO)
    public class MyTaskCreateDto
    {
        // Görevin başlığını temsil eden özellik
        public string MyTask_Title { get; set; } = default!;

        // Görevin açıklamasını temsil eden özellik
        public string MyTask_Description { get; set; } = default!;

        // Görevin bitiş tarihini temsil eden özellik
        public DateTime MyTask_DeadLine { get; set; } = default!;

        // Görevin durumunu temsil eden özellik, NotStarted, InProgress, Completed olabilir
        public MyTaskStatus MyTask_Status { get; set; } = default!;

        // Görevin atanmış olduğu kullanıcının kimlik bilgisini temsil eden özellik
        public int User_Id { get; set; } = default!;

        // Aşağıdaki satırın yorum satırından çıkarılması durumunda, 
        // MyTaskCreateDto nesnesinin içinde bir User nesnesi de barındırılabilir.
        //public User User { get; set; } = default!;
    }
}

// Business katmanındaki Update talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;  // Odanın ait olduğu projeyi temsil eden User sınıfını kullanmak için gerekli isim alanı

namespace Business.Models.Request.Update
{
    // Oda güncelleme işlemi için kullanılacak DTO sınıfı
    public class RoomUpdateDto
    {
        // Oda adını temsil eden özellik
        public string Room_Name { get; set; }

        // Odaya atanmış olan kullanıcının kimlik bilgisini temsil eden özellik
        public int UserId { get; set; }
    }
}

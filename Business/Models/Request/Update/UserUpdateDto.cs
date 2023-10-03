// Business katmanındaki Update talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;  // Kullanıcının tipini temsil eden UserType enumunu kullanmak için gerekli isim alanı

namespace Business.Models.Request.Update
{
    // Kullanıcı güncelleme işlemi için kullanılacak DTO sınıfı
    public class UserUpdateDto
    {
        // Kullanıcının TC kimlik numarasını temsil eden özellik
        public string Tc_no { get; set; } = default!;

        // Kullanıcının tam adını temsil eden özellik
        public string Fullname { get; set; } = default!;

        // Kullanıcının kullanıcı adını temsil eden özellik
        public string UserName { get; set; } = default!;

        // Kullanıcının e-posta adresini temsil eden özellik
        public string Email { get; set; } = default!;

        // Kullanıcının telefon numarasını temsil eden özellik
        public string Phone { get; set; } = default!;

        // Kullanıcının tipini temsil eden özellik
        public UserType UserType { get; set; }
    }
}

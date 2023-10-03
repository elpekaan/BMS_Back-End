// Business katmanındaki Functional talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
namespace Business.Models.Request.Functional
{
    // Giriş işlemi için kullanılacak DTO sınıfı
    public class LoginDto
    {
        // Kullanıcı adını temsil eden özellik
        public string UserName { get; set; } = default!;

        // Şifreyi temsil eden özellik
        public string Password { get; set; } = default!;
    }
}

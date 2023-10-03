// Business katmanındaki Functional talepleri için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
namespace Business.Models.Request.Functional
{
    // Kayıt işlemi için kullanılacak DTO sınıfı
    public class RegisterDto
    {
        // TC kimlik numarasını temsil eden özellik
        public string Tc_no { get; set; } = default!;

        // Tam adı temsil eden özellik
        public string FullName { get; set; } = default!;

        // Kullanıcı adını temsil eden özellik
        public string UserName { get; set; } = default!;

        // E-posta adresini temsil eden özellik
        public string Email { get; set; } = default!;

        // Telefon numarasını temsil eden özellik
        public string Phone { get; set; } = default!;

        // Şifreyi temsil eden özellik
        public string Password { get; set; } = default!;
    }
}

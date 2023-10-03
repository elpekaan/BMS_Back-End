// Business katmanındaki kullanıcı profil bilgilerini döndürmek için kullanılacak DTO (Data Transfer Object) sınıfını oluşturuyoruz.
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Response
{
    // Kullanıcı profil bilgilerini döndürmek için kullanılacak DTO sınıfı
    public class UserProfileDto
    {
        // Kullanıcının kimlik bilgisini temsil eden özellik
        public int Id { get; set; } = default!;

        // Kullanıcının kullanıcı adını temsil eden özellik
        public string UserName { get; set; } = default!;

        // Kullanıcının tam adını temsil eden özellik
        public string FullName { get; set; } = default!;

        // Kullanıcının e-posta adresini temsil eden özellik
        public string Email { get; set; } = default!;

        // Kullanıcının telefon numarasını temsil eden özellik
        public string Phone { get; set; } = default!;

        // Kullanıcının TC kimlik numarasını temsil eden özellik
        public string Tc_no { get; set; } = default!;

        // Kullanıcının tipini temsil eden özellik
        public UserType UserType { get; set; }

        // Kullanıcının sahip olduğu biletleri temsil eden koleksiyon özelliği
        public List<Ticket> Tickets { get; set; } = default!;

        // Kullanıcının sahip olduğu görevleri temsil eden koleksiyon özelliği
        public List<MyTask> MyTasks { get; set; } = default!;

        // Kullanıcının sahip olduğu projeleri temsil eden koleksiyon özelliği
        public List<Project> Projects { get; set; } = default!;

        // Kullanıcının sahip olduğu odaları temsil eden koleksiyon özelliği
        public List<Room> Rooms { get; set; } = default!;
    }
}

using Infrastructure.Data.Postgres.Entities.Base;  // Temel varlık sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Entities
{
    // User sınıfı, temel varlık sınıfından türer ve int türündeki bir kimlik alanına sahiptir.
    public class User : Entity<int>
    {
        // Kullanıcının TC kimlik numarasını temsil eden özellik
        public string Tc_no { get; set; } = default!;

        // Kullanıcının tam adını temsil eden özellik
        public string FullName { get; set; } = default!;

        // Kullanıcının kullanıcı adını temsil eden özellik
        public string UserName { get; set; } = default!;

        // Kullanıcının e-posta adresini temsil eden özellik
        public string Email { get; set; } = default!;

        // Kullanıcının telefon numarasını temsil eden özellik
        public string Phone { get; set; } = default!;

        // Kullanıcının şifreleme için kullanılacak tuzunu temsil eden özellik
        public byte[] PasswordSalt { get; set; } = default!;

        // Kullanıcının şifresini temsil eden özellik
        public byte[] PasswordHash { get; set; } = default!;

        // Kullanıcının tipini temsil eden özellik, Admin, TeamLead, Developer olabilir
        public UserType UserType { get; set; }

        // Kullanıcının sahip olduğu görevleri temsil eden koleksiyon özelliği
        public ICollection<MyTask> MyTasks { get; set; }

        // Kullanıcının sahip olduğu odaları temsil eden koleksiyon özelliği
        public ICollection<Room> Rooms { get; set; }

        // Kullanıcının sahip olduğu ticket'ları temsil eden koleksiyon özelliği
        public ICollection<Ticket> Tickets { get; set; }

        // Kullanıcının sahip olduğu projeleri temsil eden koleksiyon özelliği
        public ICollection<Project> Projects { get; set; }
    }

    // Kullanıcının tipini belirten enum (numaralandırma) türü
    public enum UserType
    {
        Admin,      // Yönetici tipinde kullanıcı
        TeamLead,   // Takım lideri tipinde kullanıcı
        Developer   // Geliştirici tipinde kullanıcı
    }
}

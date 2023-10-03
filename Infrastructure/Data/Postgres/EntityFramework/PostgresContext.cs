using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Entities.Base;  // Entity sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework.Configurations;  // Kullanılacak konfigürasyon sınıflarını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DbContext, DbContextOptions ve ModelBuilder sınıflarını kullanmak için gerekli isim alanları
using Microsoft.Extensions.Configuration;  // IConfiguration sınıfını kullanmak için gerekli isim alanı
using System;  // Console sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.EntityFramework
{
    // PostgreSQL veritabanı bağlantısını temsil eden context sınıfı
    public class PostgresContext : DbContext
    {
        // Uygulama yapılandırma bilgilerini tutan IConfiguration örneği
        private readonly IConfiguration _configuration;

        // PostgresContext sınıfının constructor metodu
        public PostgresContext(DbContextOptions<PostgresContext> options, IConfiguration configuration) : base(options)
        {
            // Constructor'da alınan IConfiguration örneğini _configuration alanına atayan blok
            _configuration = configuration;
        }

        // Model oluşturulurken yapılacak özel konfigürasyonları içeren metot
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DbContext sınıfının OnModelCreating metodu çağrılır
            base.OnModelCreating(modelBuilder);

            // Her bir konfigürasyon sınıfını uygulayan ve veritabanındaki tablo yapısını belirleyen blok
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new MyTaskConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }

        // DbContext sınıfının konfigürasyonunu yaparken yapılandırma seçeneklerini özelleştiren metot
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // DbContext sınıfının OnConfiguring metodu çağrılır
            base.OnConfiguring(optionsBuilder);

            // Uygulama yapılandırma dosyasındaki EnvironmentAlias değerini kontrol eden kısım
            if (_configuration["EnvironmentAlias"] == "DEV")
            {
                // Geliştirme ortamında çalışırken SQL sorgularını konsola yazan blok
                optionsBuilder.LogTo(Console.Write);
            }
        }

        // Veritabanındaki User tablosunu temsil eden DbSet özelliği
        public DbSet<User> User => Set<User>();

        // Veritabanındaki UserToken tablosunu temsil eden DbSet özelliği
        public DbSet<UserToken> UserTokens => Set<UserToken>();

        // Veritabanındaki Room tablosunu temsil eden DbSet özelliği
        public DbSet<Room> Rooms => Set<Room>();

        // Veritabanındaki MyTask tablosunu temsil eden DbSet özelliği
        public DbSet<MyTask> Tasks => Set<MyTask>();

        // Veritabanındaki Project tablosunu temsil eden DbSet özelliği
        public DbSet<Project> Projects => Set<Project>();

        // Veritabanındaki Ticket tablosunu temsil eden DbSet özelliği
        public DbSet<Ticket> Tickets => Set<Ticket>();
    }
}

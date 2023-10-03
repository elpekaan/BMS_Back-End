using Core.Utilities;  // DateTimeUtilities sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Entities.Base.Interface;  // IEntity arayüzünü kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories;  // Kullanılacak repository sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // Kullanılacak repository arayüzlerini kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // EntityState ve DbContext sınıflarını kullanmak için gerekli isim alanları


namespace Infrastructure.Data.Postgres
{
    // Veritabanı işlemlerini gerçekleştiren Unit of Work sınıfı
    public class UnitOfWork : IUnitOfWork
    {
        // PostgreSQL veritabanı bağlantısını sağlayan context
        private readonly PostgresContext _postgresContext;

        // Kullanıcı repository'sini önbellekte tutan özel değişken
        private UserRepository? _userRepository;

        // Kullanıcı token repository'sini önbellekte tutan özel değişken
        private UserTokenRepository? _userTokenRepository;

        // Ticket repository'sini önbellekte tutan özel değişken
        private TicketRepository? _ticketRepository;

        // Oda repository'sini önbellekte tutan özel değişken
        private RoomRepository? _roomRepository;

        // Proje repository'sini önbellekte tutan özel değişken
        private ProjectRepository? _projectRepository;

        // Görev repository'sini önbellekte tutan özel değişken
        private MyTaskRepository? _myTaskRepository;

        // UnitOfWork sınıfının constructor metodu
        public UnitOfWork(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        // Kullanıcı repository'sini döndüren özellik
        public IUserRepository Users => _userRepository ??= new UserRepository(_postgresContext);

        // Kullanıcı token repository'sini döndüren özellik
        public IUserTokenRepository UserTokens => _userTokenRepository ??= new UserTokenRepository(_postgresContext);

        // Ticket repository'sini döndüren özellik
        public ITicketRepository Tickets => _ticketRepository ??= new TicketRepository(_postgresContext);

        // Oda repository'sini döndüren özellik
        public IRoomRepository Rooms => _roomRepository ??= new RoomRepository(_postgresContext);

        // Proje repository'sini döndüren özellik
        public IProjectRepository Projects => _projectRepository ??= new ProjectRepository(_postgresContext);

        // Görev repository'sini döndüren özellik
        public IMyTaskRepository MyTasks => _myTaskRepository ??= new MyTaskRepository(_postgresContext);

        // Değişiklikleri veritabanına kaydetme işlemini gerçekleştiren metot
        public async Task<int> CommitAsync()
        {
            // Güncellenmiş varlıkları seçen LINQ sorgusu
            var updatedEntities = _postgresContext.ChangeTracker.Entries<IEntity>()
                .Where(e => e.State == EntityState.Modified)
                .Select(e => e.Entity);

            // Güncellenmiş varlıkları üzerinde döngü ile işleyen blok
            foreach (var updatedEntity in updatedEntities)
            {
                updatedEntity.UpdatedAt = DateTime.UtcNow.ToTimeZone();
            }

            // Değişiklikleri kaydedip, kaydedilen değişiklik sayısını döndüren metot
            var result = await _postgresContext.SaveChangesAsync();

            return result;
        }

        // IDisposable arayüzü metodu: Kullanılan kaynakları serbest bırakma
        public void Dispose()
        {
            _postgresContext.Dispose();
        }
    }
}

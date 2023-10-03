using Infrastructure.Data.Postgres.Repositories.Interface;  // Kullanılacak repository arayüzlerini kullanmak için gerekli isim alanı
using System;  // IDisposable arayüzünü kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres
{
    // Veritabanı işlemlerini gerçekleştirecek olan Unit of Work arayüzü
    public interface IUnitOfWork : IDisposable
    {
        // Kullanıcı işlemlerini gerçekleştirecek olan repository arayüzü
        IUserRepository Users { get; }

        // Kullanıcı token işlemlerini gerçekleştirecek olan repository arayüzü
        IUserTokenRepository UserTokens { get; }

        // Ticket işlemlerini gerçekleştirecek olan repository arayüzü
        ITicketRepository Tickets { get; }

        // Oda işlemlerini gerçekleştirecek olan repository arayüzü
        IRoomRepository Rooms { get; }

        // Proje işlemlerini gerçekleştirecek olan repository arayüzü
        IProjectRepository Projects { get; }

        // Görev işlemlerini gerçekleştirecek olan repository arayüzü
        IMyTaskRepository MyTasks { get; }

        // Değişiklikleri veritabanına kaydetme işlemini gerçekleştiren metot
        Task<int> CommitAsync();
    }
}

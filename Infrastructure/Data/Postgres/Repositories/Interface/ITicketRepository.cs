using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    // ITicketRepository arayüzü, Ticket varlıklarını işlemek için özel metodları içeren repository arayüzü
    public interface ITicketRepository : IRepository<Ticket, int>
    {
        // Belirli bir Ticket Id'ye sahip Ticket varlığını çeken metot
        Task<IList<Ticket>> GetByTicketIdAsync(int id);
    }
}

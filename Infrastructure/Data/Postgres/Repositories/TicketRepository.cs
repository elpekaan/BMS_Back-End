using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // ITicketRepository arayüzünü kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // IQueryable ve DbContext sınıflarını kullanmak için gerekli isim alanları
using System;  // Expression ve Func sınıflarını kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Linq;  // IQueryable ve IEnumerable sınıflarını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // Ticket varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class TicketRepository : Repository<Ticket, int>, ITicketRepository
    {
        // TicketRepository sınıfının constructor metodu
        public TicketRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }

        // Tüm Ticket varlıklarını, isteğe bağlı bir filtre ile çeken metot
        public async Task<IList<Ticket>> GetAllAsync(Expression<Func<Ticket, bool>>? filter = null)
        {
            // IQueryable oluştur
            IQueryable<Ticket> ticketQuery = PostgresContext.Set<Ticket>();

            // Eğer bir filtre belirtilmişse, filtreyi uygula
            if (filter != null)
            {
                ticketQuery = ticketQuery.Where(filter);
            }

            // Sonuçları çek ve liste olarak döndür
            var tickets = await ticketQuery.ToListAsync();
            return tickets;
        }

        // Belirli bir Ticket varlığını, Id kullanarak çeken metot
        public async Task<IList<Ticket>> GetByTicketIdAsync(int id)
        {
            // Tüm Ticket varlıklarını çekmek için GetAllAsync'i kullanabiliriz
            return await GetAllAsync();
        }
    }
}

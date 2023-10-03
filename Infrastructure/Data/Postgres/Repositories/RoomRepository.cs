using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // IRoomRepository arayüzünü kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // IQueryable ve DbContext sınıflarını kullanmak için gerekli isim alanları
using System;  // Expression ve Func sınıflarını kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Linq;  // IQueryable ve IEnumerable sınıflarını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // Room varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class RoomRepository : Repository<Room, int>, IRoomRepository
    {
        // RoomRepository sınıfının constructor metodu
        public RoomRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }

        // Tüm Room varlıklarını, isteğe bağlı bir filtre ile çeken metot
        public async Task<IList<Room>> GetAllAsync(Expression<Func<Room, bool>>? filter = null)
        {
            // IQueryable oluştur
            IQueryable<Room> roomQuery = PostgresContext.Set<Room>();

            // Eğer bir filtre belirtilmişse, filtreyi uygula
            if (filter != null)
            {
                roomQuery = roomQuery.Where(filter);
            }

            // Sonuçları çek ve liste olarak döndür
            var rooms = await roomQuery.ToListAsync();
            return rooms;
        }

        // Belirli bir Room varlığını, Id kullanarak çeken metot
        public async Task<IList<Room>> GetByRoomIdAsync(int id)
        {
            // Tüm Room varlıklarını çekmek için GetAllAsync'i kullanabiliriz
            return await GetAllAsync();
        }
    }
}

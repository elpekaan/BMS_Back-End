using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // IMyTaskRepository arayüzünü kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // IQueryable ve DbContext sınıflarını kullanmak için gerekli isim alanları
using System;  // Expression ve Func sınıflarını kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Linq;  // IQueryable ve IEnumerable sınıflarını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // MyTask varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class MyTaskRepository : Repository<MyTask, int>, IMyTaskRepository
    {
        // MyTaskRepository sınıfının constructor metodu
        public MyTaskRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }

        // Tüm MyTask varlıklarını, isteğe bağlı bir filtre ile çeken metot
        public async Task<IList<MyTask>> GetAllAsync(Expression<Func<MyTask, bool>>? filter = null)
        {
            // IQueryable oluştur
            IQueryable<MyTask> myTaskQuery = PostgresContext.Set<MyTask>();

            // Eğer bir filtre belirtilmişse, filtreyi uygula
            if (filter != null)
            {
                myTaskQuery = myTaskQuery.Where(filter);
            }

            // Sonuçları çek ve liste olarak döndür
            var myTasks = await myTaskQuery.ToListAsync();
            return myTasks;
        }

        // Belirli bir MyTask varlığını, Id kullanarak çeken metot
        public async Task<IList<MyTask>> GetByMyTaskIdAsync(int id)
        {
            // Tüm MyTask varlıklarını çekmek için GetAllAsync'i kullanabiliriz
            return await GetAllAsync();
        }
    }
}

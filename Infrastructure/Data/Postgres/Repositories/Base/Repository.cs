using System;
using System.Collections.Generic;  // IEnumerable sınıfını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // EntityState sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Base
{
    // Genel CRUD işlemlerini içeren ve IRepository arayüzünden türetilen soyut Repository sınıfı
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        // Repository sınıfının kullanımı için gerekli PostgresContext nesnesi
        protected readonly PostgresContext PostgresContext;

        // Repository sınıfının yapıcı metodu, PostgresContext nesnesini alır
        protected Repository(PostgresContext postgresContext)
        {
            PostgresContext = postgresContext;
        }

        // Varlık eklemek için asenkron metot
        public virtual async Task AddAsync(TEntity entity)
        {
            await PostgresContext.Set<TEntity>().AddAsync(entity);
        }

        // Bir koleksiyonu eklemek için asenkron metot
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await PostgresContext.Set<TEntity>().AddRangeAsync(entities);
        }

        // Belirli bir filtreyle sorgu yaparak ilk öğeyi getiren asenkron metot
        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await PostgresContext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        // Belirli bir filtreyle sorgu yaparak tüm öğeleri getiren asenkron metot
        public virtual async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? await PostgresContext.Set<TEntity>().ToListAsync()
                : await PostgresContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        // Belirli bir Id'ye sahip varlığı getiren asenkron metot
        public virtual async Task<TEntity> GetByIdAsync(TId id)
        {
            return await PostgresContext.Set<TEntity>().FindAsync(id);
        }

        // Belirli bir filtreyle sorgu yaparak varlığı getiren asenkron metot
        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await PostgresContext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        // Belirli bir filtreyle sorgu yaparak öğe sayısını getiren asenkron metot
        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? await PostgresContext.Set<TEntity>().CountAsync()
                : await PostgresContext.Set<TEntity>().Where(filter).CountAsync();
        }

        // Bir varlığı silmek için kullanılan metot
        public virtual void Remove(TEntity entity)
        {
            PostgresContext.Set<TEntity>().Remove(entity);
        }

        // Belirli bir Id'ye sahip varlığı silmek için kullanılan metot
        public void RemoveById(TId id)
        {
            var entity = PostgresContext.Set<TEntity>().Find(id);

            if (entity != null)
            {
                Remove(entity);
            }
        }

        // Belirli bir Id'ye sahip varlığı asenkron olarak silmek için kullanılan metot
        public async Task RemoveByIdAsync<TId1>(TId1 id)
        {
            var entity = await PostgresContext.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                Remove(entity);
            }
        }

        // Bir koleksiyonu silmek için kullanılan metot
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            PostgresContext.Set<TEntity>().RemoveRange(entities);
        }

        // Bir varlığı takipten çıkarmak için kullanılan metot
        public virtual void UntrackEntity(TEntity entity)
        {
            PostgresContext.Entry(entity).State = EntityState.Detached;
        }

        // Bir varlığı güncellemek için kullanılan metot
        public virtual void Update(TEntity entity)
        {
            PostgresContext.Set<TEntity>().Update(entity);
        }

        // Bir koleksiyonu güncellemek için kullanılan metot
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            PostgresContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}

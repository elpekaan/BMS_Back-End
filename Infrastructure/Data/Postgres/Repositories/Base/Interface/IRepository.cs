using Core.Utilities.Pagination;  // Kullanılacak Pagination sınıflarını kullanmak için gerekli isim alanı
using System;
using System.Collections.Generic;  // IEnumerable ve IList sınıflarını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Base.Interface
{
    // IRepository arayüzü, genel CRUD (Create, Read, Update, Delete) işlemlerini içeren repository arayüzüdür
    public interface IRepository<TEntity, in TId> where TEntity : class
    {
        // Yeni bir varlık eklemek için kullanılan metot
        Task AddAsync(TEntity entity);

        // Bir koleksiyonu eklemek için kullanılan metot
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        // Belirli bir filtreyle sorgu yaparak ilk öğeyi getiren metot
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        // Belirli bir filtreyle sorgu yaparak tüm öğeleri getiren metot
        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);

        // Belirli bir Id'ye sahip varlığı getiren metot
        Task<TEntity> GetByIdAsync(TId id);

        // Belirli bir filtreyle sorgu yaparak varlığı getiren metot
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);

        // Belirli bir filtreyle sorgu yaparak öğe sayısını getiren metot
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? filter = null);

        // Bir varlığı silmek için kullanılan metot
        void Remove(TEntity entity);

        // Belirli bir Id'ye sahip varlığı silmek için kullanılan metot
        void RemoveById(TId id);

        // Bir koleksiyonu silmek için kullanılan metot
        void RemoveRange(IEnumerable<TEntity> entities);

        // Bir varlığı takipten çıkarmak için kullanılan metot
        void UntrackEntity(TEntity entity);

        // Bir varlığı güncellemek için kullanılan metot
        void Update(TEntity entity);

        // Bir koleksiyonu güncellemek için kullanılan metot
        void UpdateRange(IEnumerable<TEntity> entities);

        // Belirli bir Id'ye sahip varlığı asenkron olarak silmek için kullanılan metot
        Task RemoveByIdAsync<TId>(TId? id);
    }
}

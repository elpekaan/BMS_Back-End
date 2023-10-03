using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // IProjectRepository arayüzünü kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // IQueryable ve DbContext sınıflarını kullanmak için gerekli isim alanları
using System;  // Expression ve Func sınıflarını kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Linq;  // IQueryable ve IEnumerable sınıflarını kullanmak için gerekli isim alanı
using System.Linq.Expressions;  // Expression sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // Project varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class ProjectRepository : Repository<Project, int>, IProjectRepository
    {
        // ProjectRepository sınıfının constructor metodu
        public ProjectRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }

        // Tüm Project varlıklarını, isteğe bağlı bir filtre ile çeken metot
        public async Task<IList<Project>> GetAllAsync(Expression<Func<Project, bool>>? filter = null)
        {
            // IQueryable oluştur
            IQueryable<Project> projectQuery = PostgresContext.Set<Project>();

            // Eğer bir filtre belirtilmişse, filtreyi uygula
            if (filter != null)
            {
                projectQuery = projectQuery.Where(filter);
            }

            // Sonuçları çek ve liste olarak döndür
            var projects = await projectQuery.ToListAsync();
            return projects;
        }

        // Belirli bir Project varlığını, Id kullanarak çeken metot
        public async Task<IList<Project>> GetByProjectIdAsync(int id)
        {
            // Tüm Project varlıklarını çekmek için GetAllAsync'i kullanabiliriz
            return await GetAllAsync();
        }
    }
}

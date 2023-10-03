using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    // IProjectRepository arayüzü, Project varlıklarını işlemek için özel metodları içeren repository arayüzü
    public interface IProjectRepository : IRepository<Project, int>
    {
        // Belirli bir Project Id'ye sahip Project varlığını çeken metot
        Task<IList<Project>> GetByProjectIdAsync(int id);
    }
}

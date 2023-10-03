using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı
using System.Collections.Generic;  // IList sınıfını kullanmak için gerekli isim alanı
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    // IMyTaskRepository arayüzü, MyTask varlıklarını işlemek için özel metodları içeren repository arayüzü
    public interface IMyTaskRepository : IRepository<MyTask, int>
    {
        // Belirli bir MyTask Id'ye sahip MyTask varlığını çeken metot
        Task<IList<MyTask>> GetByMyTaskIdAsync(int id);
    }
}

using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    // IUserTokenRepository arayüzü, UserToken varlıklarını işlemek için genel repository arayüzüdür
    public interface IUserTokenRepository : IRepository<UserToken, string>
    {
        // Belirli bir token'e sahip UserToken varlığını özellikleriyle birlikte çeken metot
        Task<UserToken?> GetWithPropertiesAsync(string token);
    }
}

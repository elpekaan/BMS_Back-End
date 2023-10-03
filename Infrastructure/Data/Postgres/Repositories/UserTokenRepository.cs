using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // IUserTokenRepository arayüzünü kullanmak için gerekli isim alanı
using Microsoft.EntityFrameworkCore;  // DbContext ve EntityFrameworkCore sınıflarını kullanmak için gerekli isim alanları
using System.Threading.Tasks;  // Task sınıfını ve Task<TResult> sınıfını kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // UserTokenRepository sınıfı, UserToken varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class UserTokenRepository : Repository<UserToken, string>, IUserTokenRepository
    {
        // UserTokenRepository sınıfının constructor metodu
        public UserTokenRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }

        // Belirli bir token'e sahip UserToken varlığını çeken metot
        public async Task<UserToken?> GetWithPropertiesAsync(string token)
        {
            return await PostgresContext.UserTokens
                .Include(userToken => userToken.User)  // User ilişkisini içeriye dahil et
                .AsNoTracking()  // Değişiklik izleme özelliğini kapat
                .FirstOrDefaultAsync(t => t.Token == token);  // Belirli bir token'e sahip UserToken varlığını çek
        }
    }
}

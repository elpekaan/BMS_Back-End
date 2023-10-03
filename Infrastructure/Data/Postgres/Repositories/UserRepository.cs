using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.EntityFramework;  // PostgresContext sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base;  // Repository sınıfını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Interface;  // IUserRepository arayüzünü kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories
{
    // UserRepository sınıfı, User varlıklarını işlemek için özel metodları içeren repository sınıfı
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        // UserRepository sınıfının constructor metodu
        public UserRepository(PostgresContext postgresContext) : base(postgresContext)
        {
        }
    }
}

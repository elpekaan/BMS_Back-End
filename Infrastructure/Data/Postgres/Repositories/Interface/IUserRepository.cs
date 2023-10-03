using Infrastructure.Data.Postgres.Entities;  // Kullanılacak varlık (entity) sınıflarını kullanmak için gerekli isim alanı
using Infrastructure.Data.Postgres.Repositories.Base.Interface;  // IRepository arayüzünü kullanmak için gerekli isim alanı

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    // IUserRepository arayüzü, User varlıklarını işlemek için genel repository arayüzüdür
    public interface IUserRepository : IRepository<User, int>
    {
    }
}

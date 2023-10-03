// UserService sınıfı, BaseService sınıfını genişleterek IUserService arayüzünü uygular
using System;
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services
{
    // UserService sınıfı, IUserService arayüzünü uygular
    public class UserService : BaseService<User, int, UserProfileDto>, IUserService
    {
        // Constructor metodu, bağımlılıkları enjekte eder
        public UserService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Users, mapperHelper)
        {
        }
    }
}

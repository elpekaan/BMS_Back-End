// MyTask servisi sınıfı, BaseService sınıfını genişleterek IMyTaskService arayüzünü uygular
using System;
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;

namespace Business.Services
{
    // MyTaskService sınıfı, IMyTaskService arayüzünü uygular
    public class MyTaskService : BaseService<MyTask, int, MyTaskInfoDto>, IMyTaskService
    {
        // Constructor metodu, bağımlılıkları enjekte eder
        public MyTaskService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.MyTasks, mapperHelper)
        {
        }
    }
}

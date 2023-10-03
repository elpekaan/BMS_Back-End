// Project servisi sınıfı, BaseService sınıfını genişleterek IProjectService arayüzünü uygular
using System;
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;

namespace Business.Services
{
    // ProjectService sınıfı, IProjectService arayüzünü uygular
    public class ProjectService : BaseService<Project, int, ProjectInfoDto>, IProjectService
    {
        // Constructor metodu, bağımlılıkları enjekte eder
        public ProjectService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Projects, mapperHelper)
        {
        }
    }
}



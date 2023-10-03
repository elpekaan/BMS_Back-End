// Room servisi sınıfı, BaseService sınıfını genişleterek IRoomService arayüzünü uygular
using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Core.Results;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    // RoomService sınıfı, IRoomService arayüzünü uygular
    public class RoomService : BaseService<Room, int, RoomInfoDto>, IRoomService
    {
        // Constructor metodu, bağımlılıkları enjekte eder
        public RoomService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Rooms, mapperHelper)
        {
        }
    }
}

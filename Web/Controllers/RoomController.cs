using System;
using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Base.Interface;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class RoomController : BaseCRUDController<Room, int, RoomCreateDto, RoomUpdateDto, RoomInfoDto>
    {
        public RoomController(IRoomService service) : base(service)
        {
        }
    }
}


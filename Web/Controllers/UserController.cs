using Business.Models.Request.Functional;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class UserController : BaseCRUDController<User, int, RegisterDto, UserUpdateDto, UserProfileDto>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}

using System;
using Business.Models.Response;
using Business.Services.Base.Interface;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services.Interface
{
	public interface IUserService : IBaseService<User, int, UserProfileDto>
    {
	}
}


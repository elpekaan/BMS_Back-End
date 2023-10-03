using System;
using Business.Models.Response;
using Business.Services.Base.Interface;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services.Interface
{
	public interface IMyTaskService : IBaseService<MyTask, int, MyTaskInfoDto>
    {
	}
}


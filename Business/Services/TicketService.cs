// Ticket servisi sınıfı, BaseService sınıfını genişleterek ITicketService arayüzünü uygular
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
    // TicketService sınıfı, ITicketService arayüzünü uygular
    public class TicketService : BaseService<Ticket, int, TicketInfoDto>, ITicketService
    {
        // Constructor metodu, bağımlılıkları enjekte eder
        public TicketService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Tickets, mapperHelper)
        {
        }
    }
}

using Business.Services.Base.Interface;
using Core.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers.Base
{
    // Genel CRUD işlemlerini gerçekleştiren BaseController sınıfı
    public abstract class BaseCRUDController<TEntity, TId, TCreateDTO, TUpdateDTO, TResponseDto> : BaseController
        where TEntity : class
        where TCreateDTO : class
        where TUpdateDTO : class
        where TResponseDto : class
    {
        protected readonly IBaseService<TEntity, TId, TResponseDto> _service;

        public BaseCRUDController(IBaseService<TEntity, TId, TResponseDto> service)
        {
            _service = service;
        }

        // Tüm varlıkları getiren endpoint
        [HttpGet]
        public virtual async Task<ActionResult<DataResult<IList<TResponseDto>>>> GetAll()
            => await _service.GetAllAsync();

        // Belirli bir varlığı ID ile getiren endpoint
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<DataResult<TResponseDto>>> GetById(TId id)
            => await _service.GetByIdAsync(id);

        // Yeni bir varlık oluşturan endpoint
        [HttpPost]
        public virtual async Task<ActionResult<Result>> Create([FromBody] TCreateDTO requestDto)
            => await _service.AddFromDtoAsync(requestDto);

        // Varlığı güncelleyen endpoint
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<Result>> Update(TId id, [FromBody] TUpdateDTO entity)
            => await _service.UpdateAsync(id, entity);

        // Varlığı silen endpoint
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<Result>> Delete(TId id)
            => await _service.DeleteAsync(id);
    }
}

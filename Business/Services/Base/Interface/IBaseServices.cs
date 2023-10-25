using Core.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Base.Interface
{
    public interface IBaseService<TEntity, TId, TResponseDto>
        where TEntity : class
        where TResponseDto : class
    {
        Task<DataResult<TResponseDto>> GetByIdAsync(TId id);

        Task<DataResult<IList<TResponseDto>>> GetAllAsync();

        Task<Result> AddAsync(TEntity entity);

        Task<Result> AddFromDtoAsync(object entityDto);

        Task<Result> UpdateAsync(TId id, object entityDTO);

        Task<Result> DeleteAsync(TId id);
    }
}

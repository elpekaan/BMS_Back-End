// Genel bir servis arayüzü, CRUD operasyonlarını ve DTO kullanarak veri döndürmeyi içerir.
using Core.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Base.Interface
{
    // TEntity türünde bir varlık (entity), TId türünde bir kimlik bilgisi ve TResponseDto türünde bir DTO (Data Transfer Object) kullanarak genel bir servis arayüzü tanımlanıyor.
    public interface IBaseService<TEntity, TId, TResponseDto>
        where TEntity : class
        where TResponseDto : class
    {
        // Belirli bir kimlik bilgisine sahip varlığı getiren metot
        Task<DataResult<TResponseDto>> GetByIdAsync(TId id);

        // Tüm varlıkları getiren metot
        Task<DataResult<IList<TResponseDto>>> GetAllAsync();

        // Yeni bir varlık ekleyen metot
        Task<Result> AddAsync(TEntity entity);

        // DTO kullanarak yeni bir varlık ekleyen metot
        Task<Result> AddFromDtoAsync(object entityDto);

        // Belirli bir kimlik bilgisine sahip varlığı güncelleyen metot
        Task<Result> UpdateAsync(TId id, object entityDTO);

        // Belirli bir kimlik bilgisine sahip varlığı silen metot
        Task<Result> DeleteAsync(TId id);
    }
}

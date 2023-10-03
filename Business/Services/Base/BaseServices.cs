// Genel bir hizmet sınıfı soyut sınıfı, temel CRUD (Create, Read, Update, Delete) operasyonlarını içerir.
using Business.Services.Base.Interface;
using Core.Constants;
using Core.Results;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using Infrastructure.Data.Postgres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Base
{
    // TEntity türünde bir varlık (entity), TId türünde bir kimlik bilgisi ve TResponseDto türünde bir DTO (Data Transfer Object) kullanarak genel bir hizmet soyut sınıfı tanımlanıyor.
    public abstract class BaseService<TEntity, TId, TResponseDto> : IBaseService<TEntity, TId, TResponseDto>
        where TEntity : class
        where TResponseDto : class
    {
        // IMapperHelper, IRepository ve IUnitOfWork bağımlılıkları enjekte ediliyor.
        protected readonly IMapperHelper _mapperHelper;
        private readonly IRepository<TEntity, TId> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        // Constructor metodu, bağımlılıkları enjekte eder.
        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository, IMapperHelper mapperHelper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapperHelper = mapperHelper;
        }

        // Belirli bir kimlik bilgisine sahip varlığı getiren metot
        public virtual async Task<DataResult<TResponseDto>> GetByIdAsync(TId id)
        {
            TEntity entity = await _repository.GetByIdAsync(id);
            TResponseDto responseDto = _mapperHelper.Map<TResponseDto>(entity);
            return new DataResult<TResponseDto>(responseDto);
        }

        // Tüm varlıkları getiren metot
        public virtual async Task<DataResult<IList<TResponseDto>>> GetAllAsync()
        {
            IList<TEntity> entities = await _repository.GetAllAsync();
            IList<TResponseDto> mappedEntities = _mapperHelper.Map<IList<TResponseDto>>(entities);
            return new DataResult<IList<TResponseDto>>(mappedEntities);
        }

        // Yeni bir varlık ekleyen metot
        public virtual async Task<Result> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return new Result(Messages.SuccessfullyCreatedEntity, ResultStatus.Ok);
        }

        // DTO kullanarak yeni bir varlık ekleyen metot
        public virtual async Task<Result> AddFromDtoAsync(object entityDto)
        {
            TEntity entity = _mapperHelper.Map<TEntity>(entityDto);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return new Result(Messages.SuccessfullyCreatedEntity, ResultStatus.Ok);
        }

        // Belirli bir kimlik bilgisine sahip varlığı güncelleyen metot
        public virtual async Task<Result> UpdateAsync(TId id, object entityDTO)
        {
            TEntity entity = await _repository.GetByIdAsync(id);

            _mapperHelper.Map(entityDTO, entity);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return new Result(Messages.SuccessfullyUpdatedEntity, ResultStatus.Ok);
        }

        // Belirli bir kimlik bilgisine sahip varlığı silen metot
        public virtual async Task<Result> DeleteAsync(TId id)
        {
            await _repository.RemoveByIdAsync(id);
            await _unitOfWork.CommitAsync();
            return new Result(Messages.SuccessfullyDeletedEntity, ResultStatus.Ok);
        }
    }
}

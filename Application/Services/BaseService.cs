using AutoMapper;
using SOneWeb.Application.Interfaces;
using SOneWeb.Infrastructure.Persistence.Repositorios;

namespace SOneWeb.Application.Services
{
public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity>
        where TDto : class
        where TEntity : class
    {
        private readonly BaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(BaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

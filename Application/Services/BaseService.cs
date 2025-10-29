using SOneWeb.Application.Interfaces;
using SOneWeb.Infrastructure.Persistence.Repositorios;

namespace SOneWeb.Application.Services
{
    public class BaseService<TDto, TEntity>(BaseRepository<TEntity> repository) : IBaseService<TDto>
        where TDto : class
        where TEntity : class
    {
        private readonly BaseRepository<TEntity> _repository = repository;

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            // Aquí normalmente mapearías Entity → DTO (con AutoMapper)
            return entities.Cast<TDto>();
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity as TDto;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = dto as TEntity;
            var result = await _repository.AddAsync(entity!);
            return result as TDto ?? dto;
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = dto as TEntity;
            var result = await _repository.UpdateAsync(entity!);
            return result as TDto ?? dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}

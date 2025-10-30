namespace SOneWeb.Application.Interfaces
{
    public interface IBaseService<TDto, TEntity>
        where TDto : class
        where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<TDto> AddAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
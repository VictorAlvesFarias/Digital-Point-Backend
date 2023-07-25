using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Application.Interfaces.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);
        void RemoveAsync(TEntity item);
        void UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
    }
}

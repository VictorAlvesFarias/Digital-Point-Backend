using DigitalPoint.Infra.Context;
using Microsoft.EntityFrameworkCore;
using DigitalPoint.Application.Interfaces.BaseRepository;
using DigitalPoint.Domain.Entities;

namespace DigitalPoint.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly DbSet<TEntity> _entity;

        private readonly DigitalPointContext _context;

        public BaseRepository(DigitalPointContext entity) {
            _entity = entity.Set<TEntity>();
            _context = entity;
        }

        public async void AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);

            _context.SaveChanges();
        }

        public async void RemoveAsync(TEntity item)
        {
            _context.Remove(item);

            _context.SaveChanges();
        }

        public async void UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);

            _context.SaveChanges();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var result = await _entity.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _entity.AsNoTracking().ToListAsync();

            return result;
        }

    }
}

using Microsoft.EntityFrameworkCore;

namespace Common.Database
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().FindAsync([id], cancellationToken);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            var entity = _context.Set<TEntity>().Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity item, CancellationToken cancellationToken = default)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return item;
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = _context.Set<TEntity>().Find([id]);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

namespace Common.Database
{
    public interface IRepository<TEntity>
        where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity item, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity item, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}

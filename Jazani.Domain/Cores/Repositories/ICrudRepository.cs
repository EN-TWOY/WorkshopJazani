
namespace Jazani.Domain.Cores.Repositories
{
	public interface ICrudRepository<TEntity, ID>
	{
        Task<IReadOnlyList<TEntity>> FindAllAsync();
        Task<TEntity?> FindByIdAsync(ID id);
        Task<TEntity> SaveAsync(TEntity entity);
    }
}


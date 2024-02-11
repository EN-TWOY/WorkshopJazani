
using System.Linq.Expressions;

namespace Jazani.Domain.Cores.Repositories
{
	public interface ICrudRepository<TEntity, ID>
	{
        Task<IReadOnlyList<TEntity>> FindAllAsync();
        Task<TEntity?> FindByIdAsync(ID id);
        Task<TEntity> SaveAsync(TEntity entity);
        Task<TEntity?> FindAsync(
	        Expression<Func<TEntity, bool>> predicate,
	        List<Expression<Func<TEntity, object>>> includes = null,
	        bool disableTracking = true);
        Task<IReadOnlyList<TEntity>> FindAllAsync(
	        Expression<Func<TEntity, bool>> predicate,
	        List<Expression<Func<TEntity, object>>> includes = null,
	        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
	}
}


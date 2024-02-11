using System.Linq.Expressions;
using Jazani.Domain.Cores.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Persistences
{
    public abstract class CrudRepository<TEntity, ID> : ICrudRepository<TEntity, ID> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public CrudRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IReadOnlyList<TEntity>> FindAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> FindByIdAsync(ID id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> SaveAsync(TEntity entity)
        {
            EntityState entityState = _dbContext.Entry(entity).State;

            _ = entityState switch
            {
                EntityState.Detached => _dbContext.Set<TEntity>().Add(entity),
                EntityState.Modified => _dbContext.Set<TEntity>().Update(entity)
            };


            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate,
            List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes is not null)
            {
                query = includes.Aggregate(query, (current, include)
                    => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate,
            List<Expression<Func<TEntity, object>>> includes = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes is not null)
            {
                query = includes.Aggregate(query, (current, include)
                    => current.Include(include));
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            return await query.Where(predicate).ToListAsync();
        }
    }
}
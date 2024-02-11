using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
	public class AreaRepository: CrudRepository<Area,int>, IAreaRepository
	{
		private readonly ApplicationDbContext _dbContext;


        public AreaRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

        public async override Task<Area?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Area>()
                .AsQueryable()
                .Include(t => t.AreaType)
                .FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}


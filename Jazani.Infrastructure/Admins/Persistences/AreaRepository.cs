using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Admins.Persistences
{
	public class AreaRepository: CrudRepository<Area,int>, IAreaRepository
	{
		public AreaRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}


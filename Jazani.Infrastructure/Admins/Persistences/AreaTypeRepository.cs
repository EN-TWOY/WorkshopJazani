using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class AreaTypeRepository : CrudRepository<AreaType, int>, IAreaTypeRepository
    {

        public AreaTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}


using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences;

public class ManagementRepository : CrudRepository<Management, int> , IManagementRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ManagementRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async override Task<Management?> FindByIdAsync(int id)
    {
        return await _dbContext.Set<Management>()
            .Include(x => x.Area).ThenInclude( i => i.AreaType)
            .Include(x => x.Office)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
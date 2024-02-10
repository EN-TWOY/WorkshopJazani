using System;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class AreaTypeRepository : IAreaTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AreaTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<AreaType>> FindAllAsync()
        {
            return await _dbContext.AreaTypes.ToListAsync();
        }

        public async Task<AreaType?> FindByIdAsync(int id)
        {
            return await _dbContext.AreaTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AreaType> SaveAsync(AreaType areaType)
        {
            EntityState entityState = _dbContext.Entry(areaType).State;

            _ = entityState switch
            {
                EntityState.Detached => _dbContext.AreaTypes.Add(areaType),
                EntityState.Modified => _dbContext.AreaTypes.Update(areaType)
            };


            await _dbContext.SaveChangesAsync();

            return areaType;
        }
    }
}


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

        public Task<AreaType> SaveAsync(AreaType areaType)
        {
            throw new NotImplementedException();
        }
    }
}


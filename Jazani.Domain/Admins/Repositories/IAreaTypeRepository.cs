using System;
using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
	public interface IAreaTypeRepository
	{
		Task<IReadOnlyList<AreaType>> FindAllAsync();
		Task<AreaType?> FindByIdAsync(int id);
		Task<AreaType> SaveAsync(AreaType areaType);
	}
}


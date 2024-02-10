using Jazani.Application.Admins.Dtos.AreaTypes;


namespace Jazani.Application.Admins.Services
{
	public interface IAreaTypeService
	{
		Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync();

		Task<AreaTypeDto> FindByIdAsync(int id);

		Task<AreaTypeDto> CreateAsync(AreaTypeSaveDto saveDto);

		Task<AreaTypeDto> EditAsync(int id, AreaTypeSaveDto saveDto);

		Task<AreaTypeDto> DisabledAsync(int id);
    }
}


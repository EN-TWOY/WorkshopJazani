using Jazani.Application.Admins.Dtos.AreaTypes;


namespace Jazani.Application.Admins.Services
{
	public interface IAreaTypeService
	{
		Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync();

		Task<AreaTypeDto> FindByIdAsync(int id);

		Task<AreaTypeSimpleDto> CreateAsync(AreaTypeSaveDto saveDto);

		Task<AreaTypeSimpleDto> EditAsync(int id, AreaTypeSaveDto saveDto);

		Task<AreaTypeSimpleDto> DisabledAsync(int id);
    }
}


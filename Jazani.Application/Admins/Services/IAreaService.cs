using Jazani.Application.Admins.Dtos.Areas;

namespace Jazani.Application.Admins.Services
{
	public interface IAreaService
	{
        Task<IReadOnlyList<AreaSmallDto>> FindAllAsync();

        Task<AreaDto> FindByIdAsync(int id);

        Task<AreaSimpleDto> CreateAsync(AreaSaveDto saveDto);

        Task<AreaSimpleDto> EditAsync(int id, AreaSaveDto saveDto);

        Task<AreaSimpleDto> DisabledAsync(int id);
    }
}


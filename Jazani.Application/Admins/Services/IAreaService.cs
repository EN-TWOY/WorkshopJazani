using Jazani.Application.Admins.Dtos.Areas;

namespace Jazani.Application.Admins.Services
{
	public interface IAreaService
	{
        Task<IReadOnlyList<AreaSmallDto>> FindAllAsync();

        Task<AreaDto> FindByIdAsync(int id);

        Task<AreaDto> CreateAsync(AreaSaveDto saveDto);

        Task<AreaDto> EditAsync(int id, AreaSaveDto saveDto);

        Task<AreaDto> DisabledAsync(int id);
    }
}


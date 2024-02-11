using Jazani.Application.Admins.Dtos.Offices;

namespace Jazani.Application.Admins.Services;

public interface IOfficeService
{
    Task<IReadOnlyList<OfficeSmallDto>> FindAllAsync();
    Task<OfficeDto> FindByIdAsync(int id);
    Task<OfficeSimpleDto> CreateAsync(OfficeSaveDto saveDto);
    Task<OfficeSimpleDto> EditAsync(int id, OfficeSaveDto saveDto);
    Task<OfficeSimpleDto> DisabledAsync(int id);
}
using Jazani.Application.Admins.Dtos.Managements;
using Jazani.Application.Cores.Services;

namespace Jazani.Application.Admins.Services;

public interface IManagementService :
    IQueryService<ManagementSmallDto, ManagementDto>,
    ICommandService<ManagementSimpleDto, ManagementSaveDto, int>
{
}
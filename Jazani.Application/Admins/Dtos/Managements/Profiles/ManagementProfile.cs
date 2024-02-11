using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Managements.Profiles;

public class ManagementProfile : Profile
{
    public ManagementProfile()
    {
        CreateMap<Management, ManagementSmallDto>();
        CreateMap<Management, ManagementSimpleDto>();
        CreateMap<Management, ManagementDto>();


        CreateMap<Management, ManagementSaveDto>().ReverseMap();
    }
}
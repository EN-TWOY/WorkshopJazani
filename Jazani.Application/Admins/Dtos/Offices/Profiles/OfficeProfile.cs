using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Offices.Profiles;

public class OfficeProfile : Profile
{
    public OfficeProfile()
    {
        CreateMap<Office, OfficeDto>();
        CreateMap<Office, OfficeSimpleDto>();
        CreateMap<Office, OfficeSmallDto>();
        
        CreateMap<Office, OfficeSaveDto>().ReverseMap();
    }
    
}
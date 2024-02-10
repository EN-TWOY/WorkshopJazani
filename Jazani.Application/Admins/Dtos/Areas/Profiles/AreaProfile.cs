using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Areas.Profiles
{
	public class AreaProfile : Profile
    {
		public AreaProfile()
		{
			CreateMap<Area, AreaDto>();
			CreateMap<Area, AreaSmallDto>();

			CreateMap<Area, AreaSaveDto>().ReverseMap();
		}
	}
}


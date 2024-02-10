using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.AreaTypes.Profiles
{
	public class AreaTypeProfile : Profile
	{
		public AreaTypeProfile()
		{
			CreateMap<AreaType, AreaTypeDto>();
			CreateMap<AreaType, AreaTypeSmallDto>();
		}
	}
}


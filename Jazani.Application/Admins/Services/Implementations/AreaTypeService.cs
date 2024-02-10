using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Admins.Dtos.AreaTypes;
using AutoMapper;
using System.Collections.Generic;

namespace Jazani.Application.Admins.Services.Implementations
{
	public class AreaTypeService : IAreaTypeService
    {
        private readonly IAreaTypeRepository _areaTypeRepository;
        private readonly IMapper _mapper;

		public AreaTypeService(IAreaTypeRepository areaTypeRepository, IMapper mapper)
		{
            _areaTypeRepository = areaTypeRepository;
            _mapper = mapper;
		}

        public async Task<AreaTypeDto> CreateAsync(AreaTypeSaveDto saveDto)
        {
            AreaType areaType = _mapper.Map<AreaType>(saveDto);
            areaType.RegistrationDate = DateTime.Now;
            areaType.State = true;

            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeDto areaTypeDto = _mapper.Map<AreaTypeDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<AreaTypeDto> EditAsync(int id, AreaTypeSaveDto saveDto)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if(areaType is null)
            {
                // hacer algo
            }

            _mapper.Map<AreaTypeSaveDto, AreaType>(saveDto, areaType);

            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeDto areaTypeDto = _mapper.Map<AreaTypeDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<AreaTypeDto> DisabledAsync(int id)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if (areaType is null)
            {
                // hacer algo
            }

            areaType.State = false;


            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeDto areaTypeDto = _mapper.Map<AreaTypeDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync()
        {

            IReadOnlyList<AreaType> areaTypes = await _areaTypeRepository.FindAllAsync();

            IReadOnlyList<AreaTypeSmallDto> areaTypesDto = _mapper.Map<IReadOnlyList<AreaTypeSmallDto>>(areaTypes);

            return areaTypesDto;
        }

        public async Task<AreaTypeDto> FindByIdAsync(int id)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if (areaType is null)
            {
                // hacer algo
            }

            AreaTypeDto areaTypeDto = _mapper.Map<AreaTypeDto>(areaType);

            return areaTypeDto;
        }
    }
}


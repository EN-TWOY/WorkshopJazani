using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Application.Admins.Dtos.AreaTypes;
using AutoMapper;
using Jazani.Application.Cores.Exceptions;

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

        public async Task<AreaTypeSimpleDto> CreateAsync(AreaTypeSaveDto saveDto)
        {
            AreaType areaType = _mapper.Map<AreaType>(saveDto);
            areaType.RegistrationDate = DateTime.Now;
            areaType.State = true;

            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeSimpleDto areaTypeDto = _mapper.Map<AreaTypeSimpleDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<AreaTypeSimpleDto> EditAsync(int id, AreaTypeSaveDto saveDto)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if(areaType is null)
            {
                throw AreaTypeNotFound(id);
            }

            _mapper.Map<AreaTypeSaveDto, AreaType>(saveDto, areaType);

            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeSimpleDto areaTypeDto = _mapper.Map<AreaTypeSimpleDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<AreaTypeSimpleDto> DisabledAsync(int id)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if (areaType is null)
            {
                throw AreaTypeNotFound(id);
            }

            areaType.State = false;


            AreaType areaTypeSaved = await _areaTypeRepository.SaveAsync(areaType);

            AreaTypeSimpleDto areaTypeDto = _mapper.Map<AreaTypeSimpleDto>(areaTypeSaved);

            return areaTypeDto;
        }

        public async Task<IReadOnlyList<AreaTypeSmallDto>> FindAllAsync()
        {

            IReadOnlyList<AreaType> areaTypes = await _areaTypeRepository
                .FindAllAsync(predicate:x => x.State == true);

            IReadOnlyList<AreaTypeSmallDto> areaTypesDto = _mapper.Map<IReadOnlyList<AreaTypeSmallDto>>(areaTypes);

            return areaTypesDto;
        }

        public async Task<AreaTypeDto> FindByIdAsync(int id)
        {
            AreaType? areaType = await _areaTypeRepository.FindByIdAsync(id);

            if (areaType is null)
            {
                throw AreaTypeNotFound(id);
            }

            AreaTypeDto areaTypeDto = _mapper.Map<AreaTypeDto>(areaType);

            return areaTypeDto;
        }


        private NotFoundCoreException AreaTypeNotFound(int id)
        {
            return new NotFoundCoreException("No se encontro un registro de Tipo de Area para el id: " + id);
        }
    }
}


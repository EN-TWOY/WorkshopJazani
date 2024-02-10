using AutoMapper;
using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaService(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<AreaDto> CreateAsync(AreaSaveDto saveDto)
        {
            var area = _mapper.Map<Area>(saveDto);

            area.RegistrationDate = DateTime.Now;
            area.State = true;

            await _areaRepository.SaveAsync(area);


            return _mapper.Map<AreaDto>(area);
        }

        public async Task<AreaDto> EditAsync(int id, AreaSaveDto saveDto)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            if (area is null)
            {
                // hacer algo
            }

            _mapper.Map<AreaSaveDto, Area>(saveDto, area);

            await _areaRepository.SaveAsync(area);

            return _mapper.Map<AreaDto>(area);
        }

        public async Task<AreaDto> DisabledAsync(int id)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            if (area is null)
            {
                // hacer algo
            }

            area.State = false;

            await _areaRepository.SaveAsync(area);

            return _mapper.Map<AreaDto>(area);
        }

        public async Task<IReadOnlyList<AreaSmallDto>> FindAllAsync()
        {
            var areas = await _areaRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<AreaSmallDto>>(areas);
        }

        public async Task<AreaDto> FindByIdAsync(int id)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            if (area is null)
            {
                // hacer algo
            }

            return _mapper.Map<AreaDto>(area);
        }
    }
}


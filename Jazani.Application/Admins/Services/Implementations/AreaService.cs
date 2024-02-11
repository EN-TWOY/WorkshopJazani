using AutoMapper;
using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AreaService> _logger;

        public AreaService(IAreaRepository areaRepository, IMapper mapper, ILogger<AreaService> logger)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AreaSimpleDto> CreateAsync(AreaSaveDto saveDto)
        {
            var area = _mapper.Map<Area>(saveDto);

            area.RegistrationDate = DateTime.Now;
            area.State = true;

            await _areaRepository.SaveAsync(area);


            return _mapper.Map<AreaSimpleDto>(area);
        }

        public async Task<AreaSimpleDto> EditAsync(int id, AreaSaveDto saveDto)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            if (area is null)
            {
                // hacer algo
            }

            _mapper.Map<AreaSaveDto, Area>(saveDto, area);

            await _areaRepository.SaveAsync(area);

            return _mapper.Map<AreaSimpleDto>(area);
        }

        public async Task<AreaSimpleDto> DisabledAsync(int id)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            if (area is null)
            {
                // hacer algo
            }

            area.State = false;

            await _areaRepository.SaveAsync(area);

            return _mapper.Map<AreaSimpleDto>(area);
        }

        public async Task<IReadOnlyList<AreaSmallDto>> FindAllAsync()
        {
            var areas = await _areaRepository
                .FindAllAsync(predicate: x => x.State == true);

            return _mapper.Map<IReadOnlyList<AreaSmallDto>>(areas);
        }

        public async Task<AreaDto> FindByIdAsync(int id)
        {
            var area = await _areaRepository.FindByIdAsync(id);

            _logger.LogInformation("area:" + area?.Id);

            if (area is null)
            {
                // hacer algo
                _logger.LogWarning("[AreaService] - [FindByIdAsync]: No se encontro un registro de Area para el id: " + id);
            }

            return _mapper.Map<AreaDto>(area);
        }
    }
}


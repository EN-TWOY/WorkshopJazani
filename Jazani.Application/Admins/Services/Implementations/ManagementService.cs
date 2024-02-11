using System.Linq.Expressions;
using AutoMapper;
using Jazani.Application.Admins.Dtos.Managements;
using Jazani.Application.Cores.Exceptions;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations;

public class ManagementService : IManagementService
{
    private readonly IManagementRepository _managementRepository;
    private readonly IAreaRepository _areaRepository;
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;

    public ManagementService(IManagementRepository managementRepository, IMapper mapper, IAreaRepository areaRepository,
        IOfficeRepository officeRepository)
    {
        _managementRepository = managementRepository;
        _mapper = mapper;
        _areaRepository = areaRepository;
        _officeRepository = officeRepository;
    }


    public async Task<IReadOnlyList<ManagementSmallDto>> FindAllAsync()
    {
        var managements = await _managementRepository
            .FindAllAsync(
                predicate: x => x.State == true,
                orderBy: x => x.OrderByDescending(x => x.Id)
            );

        return _mapper.Map<IReadOnlyList<ManagementSmallDto>>(managements);
    }

    public async Task<ManagementDto> FindByIdAsync(int id)
    {
        // var management = await _managementRepository
        //     .FindAsync(
        //         predicate: x => x.Id == id,
        //         includes: new List<Expression<Func<Management, object>>>()
        //         {
        //             i => i.Area,
        //             i => i.Office
        //         }
        //     );

        var management = await _managementRepository.FindByIdAsync(id);
        
        if (management == null) throw NotFoundManagement(id);

        return _mapper.Map<ManagementDto>(management);
    }

    public async Task<ManagementSimpleDto> CreateAsync(ManagementSaveDto saveDto)
    {
        var management = _mapper.Map<Management>(saveDto);
        management.RegistrationDate = DateTime.Now;
        management.State = true;

        await CheckExistenceOfRelationships(saveDto);

        await _managementRepository.SaveAsync(management);

        return _mapper.Map<ManagementSimpleDto>(management);
    }

    public async Task<ManagementSimpleDto> EditAsync(int id, ManagementSaveDto saveDto)
    {
        var management = await _managementRepository.FindByIdAsync(id);

        if (management == null) throw NotFoundManagement(id);

        await CheckExistenceOfRelationships(saveDto);

        _mapper.Map<ManagementSaveDto, Management>(saveDto, management);

        await _managementRepository.SaveAsync(management);

        return _mapper.Map<ManagementSimpleDto>(management);
    }

    public async Task<ManagementSimpleDto> DisabledAsync(int id)
    {
        var management = await _managementRepository.FindByIdAsync(id);

        if (management == null) throw NotFoundManagement(id);

        management.State = false;

        await _managementRepository.SaveAsync(management);

        return _mapper.Map<ManagementSimpleDto>(management);
    }


    private NotFoundCoreException NotFoundManagement(int id) => new($"Gestion con el id {id} no encontrado.");

    private NotFoundCoreException NotFoundArea(int id) => new($"Area con el id {id} no encontrado.");

    private NotFoundCoreException NotFoundOffice(int id) => new($"Oficina con el id {id} no encontrado.");

    private async Task CheckExistenceOfRelationships(ManagementSaveDto saveDto)
    {
        var area = await _areaRepository.FindByIdAsync(saveDto.AreaId);
        if (area == null) throw NotFoundArea(saveDto.AreaId);

        var office = await _officeRepository.FindByIdAsync(saveDto.OfficeId);
        if (office == null) throw NotFoundOffice(saveDto.OfficeId);
    }
}
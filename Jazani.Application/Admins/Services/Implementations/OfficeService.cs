using AutoMapper;
using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Application.Cores.Exceptions;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations;

public class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMapper _mapper;


    public OfficeService(IOfficeRepository officeRepository, IMapper mapper)
    {
        _officeRepository = officeRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<OfficeSmallDto>> FindAllAsync()
    {
        var offices = await _officeRepository.FindAllAsync();

        return _mapper.Map<IReadOnlyList<OfficeSmallDto>>(offices);
    }

    public async Task<OfficeDto> FindByIdAsync(int id)
    {
        var office = await _officeRepository.FindByIdAsync(id);

        if (office == null)
        {
            throw OfficeNotFound(id);
        }

        return _mapper.Map<OfficeDto>(office);
    }

    public async Task<OfficeSimpleDto> CreateAsync(OfficeSaveDto saveDto)
    {
        var office = _mapper.Map<Office>(saveDto);
        office.RegistrationDate = DateTime.Now;
        office.State = true;

        await _officeRepository.SaveAsync(office);

        return _mapper.Map<OfficeSimpleDto>(office);
    }

    public async Task<OfficeSimpleDto> EditAsync(int id, OfficeSaveDto saveDto)
    {
        var office = await _officeRepository.FindByIdAsync(id);

        if (office == null)
        {
            throw OfficeNotFound(id);
        }

        _mapper.Map<OfficeSaveDto, Office>(saveDto, office);

        await _officeRepository.SaveAsync(office);

        return _mapper.Map<OfficeSimpleDto>(office);
    }

    public async Task<OfficeSimpleDto> DisabledAsync(int id)
    {
        var office = await _officeRepository.FindByIdAsync(id);
        office.State = false;

        await _officeRepository.SaveAsync(office);

        return _mapper.Map<OfficeSimpleDto>(office);
    }

    private NotFoundCoreException OfficeNotFound(int id)
    {
        return new NotFoundCoreException($"Office no encontrado con el id {id}.");
    }
}
using Microsoft.AspNetCore.Mvc;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.Offices;


namespace Jazani.Api.Controllers.Admins;

[ApiController]
[Route("api/[controller]")]
public class OfficesController : ControllerBase
{
    
    private readonly IOfficeService _officeService;
    
    public OfficesController(IOfficeService officeService)
    {
        _officeService = officeService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OfficeSmallDto>> Get()
    {
        return await _officeService.FindAllAsync();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OfficeDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<OfficeDto>>> Get(int id)
    {
        var response = await _officeService.FindByIdAsync(id);
        
        return TypedResults.Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OfficeSimpleDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
    public async Task<Results<BadRequest, CreatedAtRoute<OfficeSimpleDto>>> Post([FromBody] OfficeSaveDto saveDto)
    {
        var response = await _officeService.CreateAsync(saveDto);
        
        return TypedResults.CreatedAtRoute(response);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OfficeSimpleDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
    public async Task<Results<NotFound, BadRequest, Ok<OfficeSimpleDto>>> Put(int id, [FromBody] OfficeSaveDto saveDto)
    {
        var response = await _officeService.EditAsync(id, saveDto);
        
        return TypedResults.Ok(response);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OfficeSimpleDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<OfficeSimpleDto>>> Delete(int id)
    {
        var response = await _officeService.DisabledAsync(id);
        
        return TypedResults.Ok(response);
    }
    
}
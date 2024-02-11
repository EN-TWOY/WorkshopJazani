using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.Managements;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins;

[ApiController]
[Route("api/[controller]")]
public class ManagementsController : ControllerBase
{
    private readonly IManagementService _managementService;

    public ManagementsController(IManagementService managementService)
    {
        _managementService = managementService;
    }

    [HttpGet]
    public async Task<IEnumerable<ManagementSmallDto>> Get()
    {
        return await _managementService.FindAllAsync();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManagementDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<ManagementDto>>> Get(int id)
    {
        var response = await _managementService.FindByIdAsync(id);
        
        return TypedResults.Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ManagementSimpleDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
    public async Task<Results<NotFound ,BadRequest, CreatedAtRoute<ManagementSimpleDto>>> Post([FromBody] ManagementSaveDto saveDto)
    {
        var response = await _managementService.CreateAsync(saveDto);
        
        return TypedResults.CreatedAtRoute(response);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManagementSimpleDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
    public async Task<Results<NotFound, BadRequest, Ok<ManagementSimpleDto>>> Put(int id, [FromBody] ManagementSaveDto saveDto)
    {
        var response = await _managementService.EditAsync(id, saveDto);
        
        return TypedResults.Ok(response);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManagementSimpleDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
    public async Task<Results<NotFound, Ok<ManagementSimpleDto>>> Delete(int id)
    {
        var response = await _managementService.DisabledAsync(id);
        
        return TypedResults.Ok(response);
    }
}
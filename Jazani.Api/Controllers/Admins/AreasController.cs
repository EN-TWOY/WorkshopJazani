using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<IEnumerable<AreaSmallDto>> Get()
        {
            return await _areaService.FindAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AreaDto>>> Get(int id)
        {
            var response = await _areaService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AreaSimpleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<AreaSimpleDto>>> Post([FromBody] AreaSaveDto saveDto)
        {
            var response = await _areaService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound, BadRequest, Ok<AreaSimpleDto>>> Put(int id, [FromBody] AreaSaveDto saveDto)
        {
            var response = await _areaService.EditAsync(id, saveDto);

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AreaSimpleDto>>> Delete(int id)
        {
            var response = await _areaService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}


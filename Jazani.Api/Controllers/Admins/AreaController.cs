using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<IEnumerable<AreaSmallDto>> Get()
        {
            return await _areaService.FindAllAsync();
        }


        [HttpGet("{id}")]
        public async Task<AreaDto> Get(int id)
        {
            return await _areaService.FindByIdAsync(id);
        }

        [HttpPost]
        public async Task<AreaDto> Post([FromBody] AreaSaveDto saveDto)
        {
            return await _areaService.CreateAsync(saveDto);
        }

        [HttpPut("{id}")]
        public async Task<AreaDto> Put(int id, [FromBody] AreaSaveDto saveDto)
        {
            return await _areaService.EditAsync(id, saveDto);
        }

        [HttpDelete("{id}")]
        public async Task<AreaDto> Delete(int id)
        {
            return await _areaService.DisabledAsync(id);
        }
    }
}


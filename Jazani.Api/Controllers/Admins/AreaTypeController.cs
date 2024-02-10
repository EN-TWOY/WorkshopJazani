using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaTypeController : ControllerBase
    {
        private readonly IAreaTypeRepository _areaTypeRepository;

        public AreaTypeController(IAreaTypeRepository areaTypeRepository)
        {
            _areaTypeRepository = areaTypeRepository;
        }



        [HttpGet]
        public async Task<IEnumerable<AreaType>> Get()
        {
            return await _areaTypeRepository.FindAllAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<AreaType> Get(int id)
        {
            return await _areaTypeRepository.FindByIdAsync(id);
        }

    }
}


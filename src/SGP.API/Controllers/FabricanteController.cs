using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGP.API.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SGP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FabricanteController : ApplicationController
    {
        private readonly IMapper _mapper;
        public FabricanteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(QueryResult<FabricanteDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] FabricanteFilter filter)
        {
            try
            {
                var fabricante = _mapper.Map<QueryResult<FabricanteDTO>>(await this.GatewayServiceProvider.Get<IFabricanteService>().Get(filter));

                return Ok(fabricante);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<FabricanteDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var obj = _mapper.Map<FabricanteDTO>(await this.GatewayServiceProvider.Get<IFabricanteService>().Get(id.Value));

            if (obj is null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<FabricanteDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] FabricanteDTO obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<FabricanteDTO>(await this.GatewayServiceProvider.Get<IFabricanteService>().Add(obj)));
        }

        [HttpPatch]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<FabricanteDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch([FromBody] FabricanteDTO obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<FabricanteDTO>(await this.GatewayServiceProvider.Get<IFabricanteService>().Update(obj)));
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<FabricanteDTO>> Delete(long id)
        {
           
            await this.GatewayServiceProvider.Get<IFabricanteService>().Delete(id);

            return NoContent();
        }

    }
}

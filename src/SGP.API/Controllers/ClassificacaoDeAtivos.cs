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

namespace SGP.Patrimony.Service.PatrimonyService
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassificacaoDeAtivosController : ApplicationController
    {
        private readonly IMapper _mapper;
        public ClassificacaoDeAtivosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(QueryResult<ClassificacaoDeAtivosDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] ClassificacaoDeAtivosFilter filter)
        {
            try
            {
                var objDoItems = _mapper.Map<QueryResult<ClassificacaoDeAtivosDTO>>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get(filter));

                return Ok(objDoItems);
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
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var obj = _mapper.Map<ClassificacaoDeAtivosDTO>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get(id.Value));

            if (obj is null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] ClassificacaoDeAtivosDTO obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<ClassificacaoDeAtivosDTO>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Add(obj)));
        }

        [HttpPatch]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch([FromBody] ClassificacaoDeAtivosDTO obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<ClassificacaoDeAtivosDTO>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Update(obj)));
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClassificacaoDeAtivosDTO>> Delete(long id)
        {
            await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Delete(id);

            return NoContent();
        }

    }
}

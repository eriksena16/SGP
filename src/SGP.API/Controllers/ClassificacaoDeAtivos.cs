using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGP.API.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
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
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClassificacaoDeAtivosViewModel>>> Get()
        {
            var objDoItems = _mapper.Map<IEnumerable<ClassificacaoDeAtivosViewModel>>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get());

            return Ok(objDoItems);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var obj = _mapper.Map<ClassificacaoDeAtivosViewModel>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get(id.Value));

            if (obj is null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] ClassificacaoDeAtivos obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<ClassificacaoDeAtivosViewModel>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Create(obj)));
        }

        [HttpPatch]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch([FromBody] ClassificacaoDeAtivos obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<ClassificacaoDeAtivosViewModel>(await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Update(obj)));
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<ClassificacaoDeAtivosViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ClassificacaoDeAtivosViewModel>> Delete(long? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var obj = await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Get(id.Value);

            if (obj is null)
            {
                return NotFound();
            }

            await this.GatewayServiceProvider.Get<IClassificacaoDeAtivosService>().Delete(obj);

            return NoContent();
        }

    }
}

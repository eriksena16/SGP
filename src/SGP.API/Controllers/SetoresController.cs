using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGP.API.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SGP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetoresController : ApplicationController
    {
        private readonly IMapper _mapper;

        public SetoresController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<SetorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SetorViewModel>>> Get()
        {
            var categoriaDoItems = _mapper.Map<IEnumerable<SetorViewModel>>(await this.GatewayServiceProvider.Get<ISetorService>().Get());

            return Ok(categoriaDoItems);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<SetorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var categoria = _mapper.Map<SetorViewModel>(await this.GatewayServiceProvider.Get<ISetorService>().Get(id.Value));

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<SetorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] SetorViewModel obj)
        {
            if (obj is null)
                return BadRequest();

            return Ok(_mapper.Map<SetorViewModel>(await this.GatewayServiceProvider.Get<ISetorService>().Add(obj)));
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<SetorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SetorViewModel>> Delete(long id)
        {

            await this.GatewayServiceProvider.Get<ISetorService>().Delete(id);

            return NoContent();
        }

        [HttpPatch]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<SetorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SetorViewModel>> Patch(SetorViewModel obj)
        {

            if (obj is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SetorViewModel>(await this.GatewayServiceProvider.Get<ISetorService>().Update(obj)));

        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGP.API.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SGP.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ApplicationController
    {
        private readonly IMapper _mapper;
        public CategoriasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(QueryResult<CategoriaDoItemDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery]CategoriaFilter filter)
        {
            try
            {
               return Ok(_mapper.Map<QueryResult<CategoriaDoItemDTO>>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(filter)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        /// <summary>
        /// Rota de Requisição da categoria do equipamento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<CategoriaDoItemDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var categoria = _mapper.Map<CategoriaDoItemDTO>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id.Value));

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriaItemDtq"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(CategoriaDoItemDTQ), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CategoriaDoItemDTQ categoriaItemDtq)
        {
            if (categoriaItemDtq is null)
                return BadRequest();

            var categoria = _mapper.Map<CategoriaDoItemDTQ, CategoriaDoItemDTO>(categoriaItemDtq);

            return Ok(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Add(categoria));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriaDoItemViewModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<CategoriaDoItemDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch( long id, CategoriaDoItemDTO categoriaDoItemViewModel)
        {
            if (id != categoriaDoItemViewModel.Id)
                return BadRequest();

            var categoria = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id);

            categoria.Id = categoriaDoItemViewModel.Id;
            categoria.Nome = categoriaDoItemViewModel.Nome;

            return Ok(_mapper.Map<CategoriaDoItemDTO>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(categoria)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:long}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<CategoriaDoItemDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoriaDoItemDTO>> Delete(long id)
        {

            await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Delete(id);

            return NoContent();
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SGP.API.Code;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
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
        [ProducesResponseType(typeof(QueryResult<CategoriaDoItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<QueryResult<CategoriaDoItemViewModel>>> Get(CategoriaFilter filter)
        {
            try
            {
               return _mapper.Map<QueryResult<CategoriaDoItemViewModel>>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(filter));
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
        [ProducesResponseType(typeof(List<CategoriaDoItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int? id)
        {
            var categoria = _mapper.Map<CategoriaDoItemViewModel>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id.Value));

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriaItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<CategoriaDoItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CategoriaDoItemViewModel categoriaItem)
        {
            if (categoriaItem is null)
                return BadRequest();

            return Ok(_mapper.Map<CategoriaDoItemViewModel>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Add(categoriaItem)));
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
        [ProducesResponseType(typeof(List<CategoriaDoItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch( long id, CategoriaDoItemViewModel categoriaDoItemViewModel)
        {
            if (id != categoriaDoItemViewModel.Id)
                return BadRequest();

            var categoria = await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Get(id);

            categoria.Id = categoriaDoItemViewModel.Id;
            categoria.Nome = categoriaDoItemViewModel.Nome;

            return Ok(_mapper.Map<CategoriaDoItemViewModel>(await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Update(categoria)));
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
        [ProducesResponseType(typeof(List<CategoriaDoItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoriaDoItemViewModel>> Delete(long id)
        {

            await this.GatewayServiceProvider.Get<ICategoriaDoItemService>().Delete(id);

            return NoContent();
        }

    }
}

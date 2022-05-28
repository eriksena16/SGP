using AutoMapper;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService:  ICategoriaDoItemService
    {

        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        public CategoriaDoItemService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDoItemDTO> Add(CategoriaDoItemDTO obj)
        {
            try
            {
                var categoria = _mapper.Map<CategoriaDoItem>(obj);

                await _repository.Create(categoria);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }


            return obj;
        }


        public async Task<CategoriaDoItemDTO> Get(long id)
        {
            var categoria = _mapper.Map<CategoriaDoItemDTO>(await _repository.Get(id));

            return categoria;

        }

        public async Task<QueryResult<CategoriaDoItemDTO>> Get(CategoriaFilter filter)
        {
            var categoria = _mapper.Map<QueryResult<CategoriaDoItemDTO>>(await _repository.Get(filter));

            return categoria;
        }

        public async Task<CategoriaDoItemDTO> Update(CategoriaDoItemDTO obj)
        {
            if (_repository.Search(c => c.Nome == obj.Nome && c.Id != obj.Id ).Result.Any()) throw new ArgumentException("já existe uma categoria com este nome!"); 
            else
            {
                try
                {
                    var categoria = _mapper.Map<CategoriaDoItemDTO, CategoriaDoItem>(obj);

                    await _repository.Update(categoria);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }

                return obj;
            }
           
        }

        public async Task Delete(long id)
        {
           await _repository.Delete(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public Task<CategoriaDoItem> GetCategoriaEquipamentos(long id)
        {
            return _repository.GetCategoriaEquipamentos(id);
        }
    }
}

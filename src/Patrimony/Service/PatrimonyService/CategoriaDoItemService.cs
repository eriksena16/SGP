using AutoMapper;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService : BaseService<CategoriaDoItem, CategoriaFilter>, ICategoriaDoItemService
    {

        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        public CategoriaDoItemService(ICategoriaRepository repository, IMapper mapper) : base(repository)
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


        public new async Task<CategoriaDoItemDTO> Get(long id)
        {
            var categoria = _mapper.Map<CategoriaDoItemDTO>(await _repository.Get(id));

            return categoria;

        }
        public new CategoriaDoItemDTO GetAsnotrack(long id)
        {
            return _mapper.Map<CategoriaDoItemDTO>(repository.GetAsNoTrackingId(id));
        }

        public new async Task<QueryResult<CategoriaDoItemDTO>> Get(CategoriaFilter filter)
        {
            var categoria = _mapper.Map<QueryResult<CategoriaDoItemDTO>>(await _repository.Get(filter));

            return categoria;
        }
        public new async Task Patch(long id, ExpandoObject patch)
        {

            var categoriaDto = GetAsnotrack(id);

            IDictionary<string, object> dict = patch;

            var categoria = _mapper.Map<CategoriaDoItem>(categoriaDto);

            Patch(categoria, dict);

            await Update(categoria);
        }
        private new async Task<CategoriaDoItem> Update(CategoriaDoItem obj)
        {
            if (_repository.Search(c => c.Nome == obj.Nome && c.Id != obj.Id).Result.Any()) throw new ArgumentException("já existe uma categoria com este nome!");
            else
            {
                try
                {
                    await _repository.Update(obj);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }

                return obj;
            }

        }

        public Task<CategoriaDoItem> GetCategoriaEquipamentos(long id)
        {
            return _repository.GetCategoriaEquipamentos(id);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }


    }
}

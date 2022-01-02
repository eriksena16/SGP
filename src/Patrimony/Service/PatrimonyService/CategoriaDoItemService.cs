using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService : ICategoriaDoItemService
    {

        private readonly ICategoriaRepository _repository;

        public CategoriaDoItemService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoriaDoItem> Create(CategoriaDoItem obj)
        {
            try
            {
                await _repository.Create(obj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }


            return obj;
        }

        public virtual async Task Delete(CategoriaDoItem obj)
        {
            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    await _repository.Delete(obj);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

        }

        public virtual async Task<CategoriaDoItem> Get(long id)
        {
            CategoriaDoItem obj = await _repository.Get(id);

            return obj;

        }

        public async Task<List<CategoriaDoItem>> Get()
        {
            var objs = await _repository.Get();

            return objs;
        }

        public async Task<CategoriaDoItem> Update(CategoriaDoItem obj)
        {
            if (!await _repository.Exists(obj.Id)) return new CategoriaDoItem();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    await _repository.Update(obj);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

            return obj;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}

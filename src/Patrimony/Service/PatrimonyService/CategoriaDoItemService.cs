using AutoMapper;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService : ICategoriaDoItemService
    {

        private readonly ICategoriaRepository _repository;
        private readonly IMapper _mapper;
        public CategoriaDoItemService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaDoItemViewModel> Add(CategoriaDoItemViewModel obj)
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

        public async Task Delete(CategoriaDoItemViewModel obj)
        {
            var categoria = _mapper.Map<CategoriaDoItem>(Get(obj.Id));

            if (categoria != null)
            {
                try
                {
                    await _repository.Delete(categoria);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

        }

        public async Task<CategoriaDoItemViewModel> Get(long id)
        {
            var categoria = _mapper.Map<CategoriaDoItemViewModel>(await _repository.Get(id));

            return categoria;

        }

        public async Task<List<CategoriaDoItemViewModel>> Get()
        {
            var categoria = _mapper.Map<List<CategoriaDoItemViewModel>>(await _repository.Get());

            return categoria;
        }

        public async Task<CategoriaDoItemViewModel> Update(CategoriaDoItemViewModel obj)
        {
            if (!await _repository.Exists(obj.Id)) return new CategoriaDoItemViewModel();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    var categoria = _mapper.Map<CategoriaDoItemViewModel, CategoriaDoItem>(obj);

                    await _repository.Update(categoria);
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

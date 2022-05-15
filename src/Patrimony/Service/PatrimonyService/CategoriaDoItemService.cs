using AutoMapper;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
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

        public async Task DeleteOld(CategoriaDoItemViewModel obj)
        {
            var categoria = _mapper.Map<CategoriaDoItem>(Get(obj.Id));

            if (categoria != null)
            {
                try
                {
                    await _repository.DeleteOld(categoria);
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
            if (_repository.Search(c => c.Nome == obj.Nome && c.Id != obj.Id ).Result.Any()) throw new ArgumentException("já existe uma categoria com este nome!"); 
            else
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

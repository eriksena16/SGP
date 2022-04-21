using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class FabricanteService : IFabricanteService
    {

        private readonly IFabricanteRepository _repository;

        public FabricanteService(IFabricanteRepository repository)
        {
            _repository = repository;
        }

        public async Task<FabricanteViewModel> Add(FabricanteViewModel obj)
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

        public async Task Delete(FabricanteViewModel obj)
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

        public virtual async Task<FabricanteViewModel> Get(long id)
        {
            Fabricante obj = await _repository.Get(id);

            return obj;

        }

        public async Task<List<FabricanteViewModel>> Get()
        {
            var objs = await _repository.Get();

            return objs;
        }

        public async Task<FabricanteViewModel> Update(FabricanteViewModel obj)
        {
            if (!await _repository.Exists(obj.Id)) return new FabricanteViewModel();

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

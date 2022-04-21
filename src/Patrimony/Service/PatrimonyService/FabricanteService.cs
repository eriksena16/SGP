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
    public class FabricanteService : IFabricanteService
    {

        private readonly IFabricanteRepository _repository;
        private readonly IMapper _mapper;
        public FabricanteService(IFabricanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FabricanteViewModel> Add(FabricanteViewModel obj)
        {
            try
            {
                var fabricante = _mapper.Map<Fabricante>(obj);

                await _repository.Create(fabricante);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }


            return obj;
        }

        public async Task Delete(FabricanteViewModel obj)
        {
            var fabricante = _mapper.Map<Fabricante>(Get(obj.Id));

            if (fabricante != null)
            {
                try
                {
                    await _repository.Delete(fabricante);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

        }

        public virtual async Task<FabricanteViewModel> Get(long id)
        {
            var fabricante = _mapper.Map<FabricanteViewModel>(await _repository.Get(id));

            return fabricante;

        }

        public async Task<List<FabricanteViewModel>> Get()
        {
            var fabricantes = _mapper.Map<List<FabricanteViewModel>>(await _repository.Get());

            return fabricantes;
        }

        public async Task<FabricanteViewModel> Update(FabricanteViewModel obj)
        {
            if (!await _repository.Exists(obj.Id)) return new FabricanteViewModel();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    var fabricante = _mapper.Map<FabricanteViewModel, Fabricante>(obj);
                    await _repository.Update(fabricante);
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

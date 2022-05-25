using AutoMapper;
using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IMapper _mapper;
        public SetorService(ISetorRepository setorRepository, IMapper mapper)
        {
            _setorRepository = setorRepository;
            _mapper = mapper;
        }

        public async Task<SetorViewModel> Add(SetorViewModel obj)
        {
            try
            {
                var setor = _mapper.Map<Setor>(obj);

                await _setorRepository.Create(setor);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }

            return obj;
        }

        public async Task Delete(SetorViewModel obj)
        {
            var setor = _mapper.Map<Setor>(Get(obj.Id));


            if (setor != null)
            {
                try
                {
                    await _setorRepository.DeleteOld(setor);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }
        }


        public virtual async Task<SetorViewModel> Get(long id)
        {
            var setor = _mapper.Map<SetorViewModel>(await _setorRepository.Get(id));

            return setor;
        }

        public async Task<List<SetorViewModel>> Get()
        {
            List<SetorViewModel> setor = _mapper.Map<List<SetorViewModel>>(await _setorRepository.Get());

            return setor;
        }


        public async Task<SetorViewModel> Update(SetorViewModel obj)
        {
            if (!await _setorRepository.Exists(obj.Id)) return new SetorViewModel();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    var setor = _mapper.Map<SetorViewModel, Setor>(obj);

                    await _setorRepository.Update(setor);
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
            _setorRepository?.Dispose();
        }

        public Task DeleteOld(SetorViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<SetorViewModel>> Get(SetorFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}

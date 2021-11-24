using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository)
        {
            _setorRepository = setorRepository;
        }

        public async Task<Setor> Create(Setor obj)
        {
            try
            {
                await _setorRepository.Create(obj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }

            return obj;
        }

        public async Task Delete(Setor obj)
        {
            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    await _setorRepository.Delete(obj);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }
        }


        public virtual async Task<Setor> Get(long id)
        {
            Setor setor = await _setorRepository.Get(id);

            return setor;
        }

        public async Task<List<Setor>> Get()
        {
            List<Setor> setor = await _setorRepository.Get();

            return setor;
        }


        public async Task<Setor> Update(Setor obj)
        {
            if (!await _setorRepository.Exists(obj.Id)) return new Setor();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    await _setorRepository.Update(obj);
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
    }
}

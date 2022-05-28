using AutoMapper;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Model.Entity;
using SGP.Patrimony.Repository.PatrimonyFilters;
using System;
using System.Linq;
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

        public async Task<FabricanteDTO> Add(FabricanteDTO obj)
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

        public async Task<QueryResult<FabricanteDTO>> Get(FabricanteFilter filter)
        {
            var fabricante = _mapper.Map<QueryResult<FabricanteDTO>>(await _repository.Get(filter));

            return fabricante;
        }

        public virtual async Task<FabricanteDTO> Get(long id)
        {
            var fabricante = _mapper.Map<FabricanteDTO>(await _repository.Get(id));

            return fabricante;

        }

        public async Task<FabricanteDTO> Update(FabricanteDTO obj)
        {
            if (_repository.Search(c => c.Nome == obj.Nome
            && c.Cnpj == obj.Cnpj).Result.Any())
                throw new ArgumentException("já existe um fabricante com este nome!");

            else
            {
                try
                {
                    var fabricante = _mapper.Map<FabricanteDTO, Fabricante>(obj);
                    await _repository.Update(fabricante);
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

    }
}

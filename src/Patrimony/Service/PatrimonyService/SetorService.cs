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
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _repository;
        private readonly IMapper _mapper;
        public SetorService(ISetorRepository setorRepository, IMapper mapper)
        {
            _repository = setorRepository;
            _mapper = mapper;
        }

        public async Task<SetorDTO> Add(SetorDTO obj)
        {
            try
            {
                Setor setor = _mapper.Map<Setor>(obj);

                await _repository.Create(setor);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }

            return obj;
        }
        public async Task<QueryResult<SetorDTO>> Get(SetorFilter filter)
        {
            QueryResult<SetorDTO> setor = _mapper.Map<QueryResult<SetorDTO>>(await _repository.Get(filter));

            return setor;
        }

        public virtual async Task<SetorDTO> Get(long id)
        {
            SetorDTO setor = _mapper.Map<SetorDTO>(await _repository.Get(id));

            return setor;
        }


        public async Task<SetorDTO> Update(SetorDTO obj)
        {
            if (_repository.Search(c=> c.Nome == obj.Nome && c.Id != obj.Id).Result.Any()) throw new ArgumentException("já existe um setor com este nome!");

            else
            {
                try
                {
                    Setor setor = _mapper.Map<SetorDTO, Setor>(obj);

                    await _repository.Update(setor);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

            return obj;

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

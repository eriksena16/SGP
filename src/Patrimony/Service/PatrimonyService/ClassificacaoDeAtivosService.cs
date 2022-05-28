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
    public class ClassificacaoDeAtivosService : IClassificacaoDeAtivosService
    {

        private readonly IClassificacaoDeAtivosRepository _repository;
        private readonly IMapper _mapper;
        public ClassificacaoDeAtivosService(IClassificacaoDeAtivosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassificacaoDeAtivosDTO> Add(ClassificacaoDeAtivosDTO obj)
        {
            try
            {
                var classificacao = _mapper.Map<ClassificacaoDeAtivos>(obj);

                await _repository.Create(classificacao);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }


            return obj;
        }

        public async Task<QueryResult<ClassificacaoDeAtivosDTO>> Get(ClassificacaoDeAtivosFilter filter)
        {
            var classificacao = _mapper.Map<QueryResult<ClassificacaoDeAtivosDTO>>(await _repository.Get(filter));

            return classificacao;
        }


        public async Task<ClassificacaoDeAtivosDTO> Get(long id)
        {
            var classificacao = _mapper.Map<ClassificacaoDeAtivosDTO>(await _repository.Get(id));

            return classificacao;

        }


        public async Task<ClassificacaoDeAtivosDTO> Update(ClassificacaoDeAtivosDTO obj)
        {

            if (_repository.Search(c => c.Nome == obj.Nome && c.Id != obj.Id).Result.Any()) throw new ArgumentException("já existe uma classificacao com este nome!");

            else
            {
                try
                {
                    ClassificacaoDeAtivos classificacao = _mapper.Map<ClassificacaoDeAtivosDTO, ClassificacaoDeAtivos>(obj);

                    await _repository.Update(classificacao);
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

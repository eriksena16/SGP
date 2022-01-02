using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class ClassificacaoDeAtivosService : IClassificacaoDeAtivosService
    {

        private readonly IClassificacaoDeAtivosRepository _repository;

        public ClassificacaoDeAtivosService(IClassificacaoDeAtivosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClassificacaoDeAtivos> Create(ClassificacaoDeAtivos obj)
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

        public async Task Delete(ClassificacaoDeAtivos obj)
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

        public virtual async Task<ClassificacaoDeAtivos> Get(long id)
        {
            ClassificacaoDeAtivos obj = await _repository.Get(id);

            return obj;

        }

        public async Task<List<ClassificacaoDeAtivos>> Get()
        {
            var objs = await _repository.Get();

            return objs;
        }

        public async Task<ClassificacaoDeAtivos> Update(ClassificacaoDeAtivos obj)
        {
            if (!await _repository.Exists(obj.Id)) return new ClassificacaoDeAtivos();

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

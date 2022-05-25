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
    public class ClassificacaoDeAtivosService : IClassificacaoDeAtivosService
    {

        private readonly IClassificacaoDeAtivosRepository _repository;
        private readonly IMapper _mapper;
        public ClassificacaoDeAtivosService(IClassificacaoDeAtivosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClassificacaoDeAtivosViewModel> Add(ClassificacaoDeAtivosViewModel obj)
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

        public async Task Delete(ClassificacaoDeAtivosViewModel obj)
        {
            var classificacao = _mapper.Map<ClassificacaoDeAtivos>(Get(obj.Id));

            if (classificacao != null)
            {
                try
                {
                    await _repository.DeleteOld(classificacao);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

        }

        public async Task<ClassificacaoDeAtivosViewModel> Get(long id)
        {
            var classificacao = _mapper.Map<ClassificacaoDeAtivosViewModel>(await _repository.Get(id));

            return classificacao;

        }

        public async Task<List<ClassificacaoDeAtivosViewModel>> Get()
        {
            var classificacao = _mapper.Map<List<ClassificacaoDeAtivosViewModel>>(await _repository.Get());

            return classificacao;
        }

        public async Task<ClassificacaoDeAtivosViewModel> Update(ClassificacaoDeAtivosViewModel obj)
        {

            if (!await _repository.Exists(obj.Id)) return new ClassificacaoDeAtivosViewModel();

            var result = Get(obj.Id);

            if (result != null)
            {
                try
                {
                    var categoria = _mapper.Map<ClassificacaoDeAtivosViewModel, ClassificacaoDeAtivos>(obj);

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

        public Task DeleteOld(ClassificacaoDeAtivosViewModel obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<ClassificacaoDeAtivosViewModel>> Get(ClassificacaoDeAtivosFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}

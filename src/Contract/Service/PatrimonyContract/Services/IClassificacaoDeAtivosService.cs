using LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IClassificacaoDeAtivosService : IGenericService<ClassificacaoDeAtivosViewModel, ClassificacaoDeAtivosFilter>
    {
    }
}

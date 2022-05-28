using SGP.Model.Entity.ViewModels;
using SGP.Patrimony.Repository.PatrimonyFilters;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IClassificacaoDeAtivosService : IGenericService<ClassificacaoDeAtivosViewModel, ClassificacaoDeAtivosFilter>
    {
    }
}

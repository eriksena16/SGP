using SGP.Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IEquipamentoService : IGenericService<Equipamento>
    {
        IEnumerable<string> DropdownListCategoriaDoItem();
        IQueryable<object> DropdownListClassificacaoDeAtivos();
        IQueryable<object> DropdownListModeloDeEquipamento();
        IQueryable<object> DropdownListFabricante();
        IQueryable<object> DropdownListSetor();
        IQueryable<object> DropdownListResponsavelDoEquipamento();
    }
}

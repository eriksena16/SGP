using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface IEquipamentoService : IGenericService<Equipamento>
    {
        IEnumerable<object> DropdownListCategoriaDoItem();
        IEnumerable<object> DropdownListClassificacaoDeAtivos();
        IEnumerable<object> DropdownListModeloDeEquipamento();
        IEnumerable<object> DropdownListFabricante();
        IEnumerable<object> DropdownListSetor();
        IEnumerable<object> DropdownListResponsavelDoEquipamento();
    }
}

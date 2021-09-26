using System.Collections.Generic;

namespace SGP.Model.Entity

{
    public class CategoriaDoItem : GenericEntity
    {
        public ICollection<Equipamento> Equipmento { get; set; }
    }
}

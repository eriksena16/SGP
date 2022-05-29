using System.Collections.Generic;

namespace SGP.Model.Entity

{
    public class CategoriaDoItem : BaseEntity
    {
        public string Nome { get; set; }
        public IEnumerable<Equipamento> Equipamentos { get; set; }
    }
}

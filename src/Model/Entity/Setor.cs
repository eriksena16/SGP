using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Setor : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

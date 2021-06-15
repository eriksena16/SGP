using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Setor : GenericEntity
    {
        public ICollection<Equipamento> Equipment { get; set; }
    }
}

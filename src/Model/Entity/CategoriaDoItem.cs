using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity

{
    public class CategoriaDoItem : GenericEntity
    {
        public ICollection<Equipamento> Equipment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity

{
    public class ItemCategory : GenericEntity
    {
        public ICollection<Equipment> Equipment { get; set; }
    }
}

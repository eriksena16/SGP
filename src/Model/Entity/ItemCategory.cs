using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity

{
    public class ItemCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}

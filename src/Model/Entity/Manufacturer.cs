using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Manufacturer : Company
    {
        public ICollection<Equipment> Equipment { get; set; }
    }
}

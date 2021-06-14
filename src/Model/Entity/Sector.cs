using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Sector : GenericEntity
    {
        public ICollection<Equipment> Equipment { get; set; }
    }
}

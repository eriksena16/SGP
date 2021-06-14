using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class EquipmentModel : GenericEntity
    {
        
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Equipment> Equipment { get; set; }

    }
}

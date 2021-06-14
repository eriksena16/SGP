using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class EquipmentModel
    {
        public int EquipmentModelId { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Equipment> Equipment { get; set; }

    }
}

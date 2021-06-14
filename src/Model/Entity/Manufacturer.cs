using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Manufacturer : Company
    {
        public ICollection<EquipmentModel> EquipmentModel { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}

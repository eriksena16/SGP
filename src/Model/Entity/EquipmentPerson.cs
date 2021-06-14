using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class EquipmentPerson : User_
    {
        public ICollection<Equipment> Equipment { get; set; }
    }
}

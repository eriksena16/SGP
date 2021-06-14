﻿using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class EquipmentModel
    {
        public int EquipmentModelId { get; set; }
        public string Name { get; set; }

        public ICollection<Equipment> Equipment { get; set; }

    }
}

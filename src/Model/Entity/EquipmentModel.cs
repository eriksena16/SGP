using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity
{
    public class EquipmentModel
    {
        public int ModeloID { get; set; }
        public string Nome { get; set; }

        public ICollection<Equipment> Equipamentos { get; set; }

    }
}

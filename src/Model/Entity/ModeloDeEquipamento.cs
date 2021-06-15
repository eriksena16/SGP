using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class ModeloDeEquipamento : GenericEntity
    {
        
        public int ManufacturerId { get; set; }
        public Fabricante Manufacturer { get; set; }

        public ICollection<Equipamento> Equipment { get; set; }

    }
}

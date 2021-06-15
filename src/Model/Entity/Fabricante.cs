using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Fabricante : Empresa
    {
        public ICollection<ModeloDeEquipamento> EquipmentModel { get; set; }
        public ICollection<Equipamento> Equipment { get; set; }
    }
}

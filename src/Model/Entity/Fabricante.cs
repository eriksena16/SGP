using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Fabricante : Empresa
    {
        public ICollection<ModeloDeEquipamento> ModeloDeEquipamento { get; set; }
        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

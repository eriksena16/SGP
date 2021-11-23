using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Fabricante : Empresa
    {

        public IList<ModeloDeEquipamento> ModeloDeEquipamento { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class ModeloDeEquipamento : GenericEntity
    {

        [Display(Name = "Fabricante")]
        public long FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        public IList<Equipamento> Equipamento { get; set; }

    }
}

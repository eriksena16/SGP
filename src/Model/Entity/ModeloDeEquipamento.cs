using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class ModeloDeEquipamento : GenericEntity
    {

        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        public ICollection<Equipamento> Equipment { get; set; }

    }
}

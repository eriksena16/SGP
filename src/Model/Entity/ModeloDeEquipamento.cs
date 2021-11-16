using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    public class ModeloDeEquipamento : GenericEntity
    {

        [Display(Name = "Fabricante")]
        public long FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        [JsonIgnore]
        [NotMapped]
        public IList<Equipamento> Equipamentos { get; set; }


    }
}

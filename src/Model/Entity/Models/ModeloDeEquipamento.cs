using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    public class ModeloDeEquipamento : BaseEntity
    {
        public string Nome { get; set; }
        public long FabricanteId { get; set; }
        [JsonIgnore]
        [ForeignKey("FabricanteId")]
        public Fabricante Fabricante { get; set; }
        [JsonIgnore]
        public IList<Equipamento> Equipamentos { get; set; }


    }
}

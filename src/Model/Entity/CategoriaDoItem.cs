using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity

{
    public class CategoriaDoItem : GenericEntity
    {
        public string Nome { get; set; }

        [JsonIgnore]
        [NotMapped]
        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity

{
    public class CategoriaDoItem : GenericEntity
    {
        public string Name { get; set; }

        public CategoriaDoItem(string name)
        {
            Name = name;
        }

        [JsonIgnore]
        [NotMapped]
        public ICollection<Equipamento> Equipmento { get; set; }
    }
}

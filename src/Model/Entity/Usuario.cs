using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{

    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Sobrenome { get; set; }
        public long GrupoId { get; set; }
        [JsonIgnore]
        [ForeignKey("GrupoId")]
        public Grupo Grupo { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class Setor : BaseEntity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

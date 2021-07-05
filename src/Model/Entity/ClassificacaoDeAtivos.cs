using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class ClassificacaoDeAtivos : GenericEntity
    {
        
        [Display(Name ="Taxa de depreciação")]
        public int TaxaDeDepreciacao { get; set; }
        [Display(Name ="Vida Útil")]
        public int VidaUtil { get; set; }

        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

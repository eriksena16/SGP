using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class ClassificacaoDeAtivos : BaseEntity
    {
        
        public int TaxaDeDepreciacao { get; set; }
        public int VidaUtil { get; set; }
        public string Nome { get; set; }

        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

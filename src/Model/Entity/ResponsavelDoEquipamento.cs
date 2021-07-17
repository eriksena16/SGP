using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class ResponsavelDoEquipamento : Usuario
    {
        public ICollection<Equipamento> Equipamento { get; set; }
    }
}

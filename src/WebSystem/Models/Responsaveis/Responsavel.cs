using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Responsaveis
{
    public class Responsavel
    {
        public int ResponsavelID { get; set; }
        public string Nome { get; set; }
     
        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Setores
{
    public class Setor
    {
        public int SetorID { get; set; }
        public string Nome { get; set; }

        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }
    }
}

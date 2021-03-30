using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Classificacoes
{
    public class Classificacao
    {
        public int ClassificacaoID { get; set; }
        public string Nome { get; set; }
        public int taxa { get; set; }

        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }
    }
}

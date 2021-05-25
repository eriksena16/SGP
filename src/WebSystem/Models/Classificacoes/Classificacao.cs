using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Classificacoes
{
    public class Classificacao
    {
        public int ClassificacaoID { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Taxa de depreciação")]
        public int taxa { get; set; }
        [Display(Name ="Vida Útil")]
        public int VidaUtil { get; set; }

        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }
    }
}

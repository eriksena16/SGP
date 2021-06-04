using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models
{
    public class Classificacao
    {
        public int ClassificacaoID { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Taxa de depreciação")]
        public int Taxa { get; set; }
        [Display(Name ="Vida Útil")]
        public int VidaUtil { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }
    }
}

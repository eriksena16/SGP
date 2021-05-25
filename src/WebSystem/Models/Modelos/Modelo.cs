using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Modelos
{
    public class Modelo
    {
        public int ModeloID { get; set; }
        public string Nome { get; set; }

        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }

    }
}

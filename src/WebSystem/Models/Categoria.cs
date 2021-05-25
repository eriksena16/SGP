using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models

{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public ICollection<Equipamento> Equipamentos { get; set; }
    }
}

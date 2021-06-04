using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity
{
    public class Responsible
    {
        public int ResponsavelID { get; set; }
        public string Nome { get; set; }
     
        public ICollection<Equipment> Equipamentos { get; set; }
    }
}

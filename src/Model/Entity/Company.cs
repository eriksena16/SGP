using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models
{
    public class Company
    {
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public ICollection<Equipment> Equipamentos { get; set; }
    }
}

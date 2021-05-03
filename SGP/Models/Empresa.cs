using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }
    }
}

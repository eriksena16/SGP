using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGP.Models.Equipamentos;

namespace SGP.Models.Equipamentos
{
    public class EquipamentoVM
    {
   
        public int EquipamentoID { get; set; }
        public int CategoriaID { get; set; }
        public int Idade { get; set; }
        public int ClassificacaoID { get; set; }
        public string Nota { get; set; }

        public string ValorDeCompra { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataDeCompra { get; set; }
        public string Modelo { get; set; }
        
        public int FornecedorID { get; set; }
        public string Serie { get; set; }
        public string Status { get; set; }
     
        public int ResponsavelID { get; set; }
      
        public int SetorID { get; set; }
    
        public string EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

    }
}

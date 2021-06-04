using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SGP.Models
{
    
    public class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Nº do Patrimonio")]
        public int EquipamentoID { get; set; }
        
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        [Display(Name ="Tempo em anos")]
        public int Idade { get; set; }

        [Display(Name = "Classificação")]
        public int ClassificacaoID { get; set; }

        [Display(Name ="Nota Fiscal")]
        [NotMapped]
        public IFormFile NotaFiscal { get; set; }
        public string NotaFiscalUrl { get; set; }

       
        [Display(Name = "Valor de Compra")]        
        
        [Column(TypeName = "money")]
        public decimal ValorDeCompra { get; set; }

        [Display(Name = "Valor Atual")]
        [Column(TypeName = "money")]
        public decimal ValorAtual { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Compra")]
        public DateTime DataDeCompra { get; set; }
        [Display(Name ="Modelo")]
        public int ModeloID { get; set; }
        [Display(Name = "Fabricante")]
        public int MarcaID { get; set; }
        [Display(Name = "Número de série")]
        public string Serie { get; set; }
        public Status Status { get; set; }
        [Display(Name = "Responsavel")]
        public int ResponsavelID { get; set; }
        [Display(Name = "Setor")]
        public int SetorID { get; set; }
        [Display(Name = "Estado")]
        public EstadoDeConservacao EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

        public Categoria Categoria { get; set; }
        public AssetClassification Classificacao { get; set; }
        public EquipmentModel Modelo { get; set; }
        public Empresa Marca { get; set; }
        public Responsible Responsavel { get; set; }
        public Sector Setor { get; set; }
        
        public decimal CalcularValorAtual(int idade)
        {
            this.Idade = idade;
            var percentual = Convert.ToDecimal(this.Classificacao.Taxa) / 100; // 0,2
            decimal vt = this.ValorDeCompra * percentual; // 3200 * 0,2 = 640

            return this.ValorAtual = this.ValorDeCompra - (vt * this.Idade);// 3200 - (640*3) = 1920

        }
    }
}

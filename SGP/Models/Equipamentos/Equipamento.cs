using SGP.Models.Categorias;
using SGP.Models.Classificacoes;
using SGP.Models.Modelos;
using SGP.Models.Marcas;
using SGP.Models.Responsaveis;
using SGP.Models.Setores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SGP.Models.Equipamentos
{
    public enum Status{Ativo, Inativo}
    public enum EstadoDeConservacao { Otimo, Bom, Ruim}
    public class Equipamento
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
        public string Nota { get; set; }

       
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
        public Status? Status { get; set; }
        [Display(Name = "Responsavel")]
        public int ResponsavelID { get; set; }
        [Display(Name = "Setor")]
        public int SetorID { get; set; }
        [Display(Name = "Estado")]
        public EstadoDeConservacao? EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

        public Categoria Categoria { get; set; }
        public Classificacao Classificacao { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Marca { get; set; }
        public Responsavel Responsavel { get; set; }
        public Setor Setor { get; set; }
        
        public decimal CalcularValorAtual(int idade)
        {
            this.Idade = idade;
            var percentual = Convert.ToDecimal(this.Classificacao.taxa) / 100; // 0,2
            decimal vt = this.ValorDeCompra * percentual; // 3200 * 0,2 = 640

            return this.ValorAtual = this.ValorDeCompra - (vt * this.Idade);// 3200 - (640*3) = 1920

        }
    }
}

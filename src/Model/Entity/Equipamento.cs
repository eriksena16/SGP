using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGP.Model.Entity
{
    
    public class Equipamento
    {

        public long EquipamentoID { get; set; }
        [Display(Name = "Nº do patrimônio")]
        public long NumeroDePatrmonio { get; set; }

        [Display(Name = "Categoria do Equipamento")]
        public long CategoriaDoItemID{ get; set; }
        public CategoriaDoItem CategoriaDoItem { get; set; }

        [Display(Name = "Idade")]
        [NotMapped]
        public int? Idade { get; set; }

        [Display(Name = "Classificação do Ativo")]
        public long ClassificacaoDeAtivosID { get; set; }
        public ClassificacaoDeAtivos ClassificacaoDeAtivos { get; set; }

        [Display(Name = "Nota Fiscal")]
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
        [Display(Name = "Modelo")]
        public long ModeloDeEquipamentoID { get; set; }
        public ModeloDeEquipamento ModeloDeEquipamento { get; set; }
        [Display(Name = "Fabricante")]
        public long FabricanteID { get; set; }
        public Fabricante Fabricante { get; set; }

        [Display(Name = "Número de série")]
        public string NumeroDeSerie { get; set; }
        [Display(Name = "Status")]
        public EquipamentoStatus EquipamentoStatus { get; set; }
        [Display(Name = "Responsavel do Equipamento")]
        public long ResponsavelDoEquipamentoID { get; set; }
        public ResponsavelDoEquipamento ResponsavelDoEquipamento { get; set; }
        [Display(Name = "Setor")]
        public long SetorID { get; set; }
        public Setor Setor { get; set; }
        [Display(Name = "Estado")]
        public EstadoDeConservacao EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

    }
}

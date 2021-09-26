using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGP.Model.Entity
{
    
    public class Equipamento
    {

        public long Id { get; set; }
        [Display(Name = "Nº do patrimônio")]
        public long NumeroDePatrmonio { get; set; }

        [Display(Name = "Categoria do Equipamento")]
        public long CategoriaDoItemId{ get; set; }
        [ForeignKey("CategoriaDoItemId")]
        public CategoriaDoItem CategoriaDoItem { get; set; }

        [Display(Name = "Idade")]
        [NotMapped]
        public int Idade { get; set; }

        [Display(Name = "Classificação do Ativo")]
        public long ClassificacaoDeAtivosId { get; set; }
        [ForeignKey("ClassificacaoDeAtivosId")]
        public ClassificacaoDeAtivos ClassificacaoDeAtivos { get; set; }

        [Display(Name = "Nota Fiscal")]
        [NotMapped]
        public IFormFile NotaFiscal { get; set; }
        public string NotaFiscalUrl { get; set; }

        [Display(Name = "Valor de Compra")]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorDeCompra { get; set; }

        [Display(Name = "Valor Atual")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorAtual { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Compra")]
        public DateTime DataDeCompra { get; set; }
        [Display(Name = "Modelo")]
        public long ModeloDeEquipamentoId { get; set; }
        [ForeignKey("ModeloDeEquipamentoId")]
        public ModeloDeEquipamento ModeloDeEquipamento { get; set; }

        [Display(Name = "Número de série")]
        public string NumeroDeSerie { get; set; }
        [Display(Name = "Status")]
        public EquipamentoStatus EquipamentoStatus { get; set; }
        [Display(Name = "Responsavel do Equipamento")]
        public long ResponsavelDoEquipamentoId { get; set; }
        [ForeignKey("ResponsavelDoEquipamentoId")]
        public ResponsavelDoEquipamento ResponsavelDoEquipamento { get; set; }
        [Display(Name = "Setor")]
        public long SetorId { get; set; }
        [ForeignKey("SetorId")]
        public Setor Setor { get; set; }
        [Display(Name = "Estado")]
        public EstadoDeConservacao EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity.ViewModels
{
   public class EquipamentoViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Nº do patrimônio")]
        public long NumeroDePatrmonio { get; set; }

        [Display(Name = "Categoria do Equipamento")]
        public int CategoriaDoItemId { get; set; }
        public CategoriaDoItem CategoriaDoItem { get; set; }
        public int Idade { get; set; }

        [Display(Name = "Classificação do Ativo")]
        public int ClassificacaoDeAtivosId { get; set; }
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
        public int ModeloDeEquipamentoId { get; set; }
        public ModeloDeEquipamento ModeloDeEquipamento { get; set; }
        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        [Display(Name = "Número de série")]
        public string NumeroDeSerie { get; set; }

        public EquipamentoStatus Status { get; set; }
        [Display(Name = "Responsavel do Equipamento")]
        public int ResponsavelDoEquipamentoId { get; set; }
        public ResponsavelDoEquipamento ResponsavelDoEquipamento { get; set; }
        [Display(Name = "Setor")]
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
        [Display(Name = "Estado")]
        public EstadoDeConservacao EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }
    }
}

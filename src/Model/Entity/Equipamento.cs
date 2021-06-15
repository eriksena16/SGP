using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGP.Model.Entity
{
    
    public class Equipamento
    {
        
        public long EquipmentId { get; set; }
        [Display(Name = "Nº do patrimônio")]
        public long PatrimonyNumber { get; set; }

        [Display(Name = "Categoria do Equipamento")]
        public int ItemCategoryId { get; set; }
        public CategoriaDoItem ItemCategory { get; set; }

        [Display(Name = "Classificação do Ativo")]
        public int AssetClassificationId { get; set; }
        public ClassificacaoDeAtivos AssetClassification { get; set; }

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
        public int EquipmentModelId { get; set; }
        public ModeloDeEquipamento EquipmentModel { get; set; }
        [Display(Name = "Fabricante")]
        public int ManufacturerId { get; set; }
        public Fabricante Manufacturer { get; set; }

        [Display(Name = "Número de série")]
        public string SerialNumber { get; set; }

        public Status Status { get; set; }
        [Display(Name = "Responsavel do Equipamento")]
        public int EquipmentPersonId { get; set; }
        public ResponsavelDoEquipamento EquipmentPerson { get; set; }
        [Display(Name = "Setor")]
        public int SectorId { get; set; }
        public Setor Sector { get; set; }
        [Display(Name = "Estado")]
        public ConservationState ConservationState { get; set; }
        public string Observation { get; set; }
        
        
       /* public decimal CalcularValorAtual(int idade)
        {
            this.Idade = idade;
            var percentual = Convert.ToDecimal(this.Classificacao.Taxa) / 100; // 0,2
            decimal vt = this.ValorDeCompra * percentual; // 3200 * 0,2 = 640

            return this.ValorAtual = this.ValorDeCompra - (vt * this.Idade);// 3200 - (640*3) = 1920

        }*/
    }
}

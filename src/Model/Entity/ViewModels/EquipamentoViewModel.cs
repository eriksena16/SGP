using Microsoft.AspNetCore.Http;
using System;

namespace SGP.Model.Entity.ViewModels
{
    public class EquipamentoViewModel : BaseEntity
    {
        public long NumeroDePatrimonio { get; set; }
        public int CategoriaDoItemId { get; set; }
        public string CategoriaDoItemNome { get; set; }
        public int? Idade { get; set; }
        public int ClassificacaoDeAtivosId { get; set; }
        public string ClassificacaoDeAtivosNome { get; set; }
        public IFormFile NotaFiscal { get; set; }
        public string NotaFiscalUrl { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal? ValorAtual { get; set; }
        public DateTime DataDeCompra { get; set; }
        public int ModeloDeEquipamentoId { get; set; }
        public string ModeloDeEquipamentoNome { get; set; }
        public int FabricanteId { get; set; }
        public int FabricanteNome { get; set; }
        public string NumeroDeSerie { get; set; }
        public EquipamentoStatus Status { get; set; }
        public int ResponsavelDoEquipamentoId { get; set; }
        public string ResponsavelDoEquipamentoNome { get; set; }
        public int SetorId { get; set; }
        public string  SetorNome { get; set; }
        public EstadoDeConservacao Conservacao { get; set; }
        public string Observacao { get; set; }
    }
}

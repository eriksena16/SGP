using System;
using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class EquipamentoDTO : BaseEntity
    {
        public long NumeroDePatrmonio { get; set; }
        public long CategoriaDoItemId { get; set; }
        public long ClassificacaoDeAtivosId { get; set; }
        public string NotaFiscalUrl { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal? ValorAtual { get; set; }
        public DateTime DataDeCompra { get; set; }
        public long ModeloDeEquipamentoId { get; set; }
        public string Serie { get; set; }
        public bool Ativo { get; set; }
        public long ResponsavelId { get; set; }
        public long SetorId { get; set; }
        public EstadoDeConservacao Status { get; set; }
        public List<Observacao> Observacoes { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SGP.Model.Entity
{

    public class Equipamento : GenericEntity
    {
        public long NumeroDePatrmonio { get; set; }
        public long CategoriaDoItemId{ get; set; }
        [JsonIgnore]
        [ForeignKey("CategoriaDoItemId")]
        public CategoriaDoItem CategoriaDoItem { get; set; }
        public long ClassificacaoDeAtivosId { get; set; }
        [JsonIgnore]
        [ForeignKey("ClassificacaoDeAtivosId")]
        public ClassificacaoDeAtivos ClassificacaoDeAtivos { get; set; }
        public string NotaFiscalUrl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorDeCompra { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorAtual { get; set; }
        public DateTime DataDeCompra { get; set; }
        public long ModeloDeEquipamentoId { get; set; }
        [JsonIgnore]
        [ForeignKey("ModeloDeEquipamentoId")]
        public ModeloDeEquipamento ModeloDeEquipamento { get; set; }
        public string Serie { get; set; }
        public EquipamentoStatus Status { get; set; }
        public long ResponsavelDoEquipamentoId { get; set; }
        [JsonIgnore]
        [ForeignKey("ResponsavelDoEquipamentoId")]
        public ResponsavelDoEquipamento ResponsavelDoEquipamento { get; set; }
        public long SetorId { get; set; }
        [JsonIgnore]
        [ForeignKey("SetorId")]
        public Setor Setor { get; set; }
        public EstadoDeConservacao EstadoDeConservacao { get; set; }
        public string Observacao { get; set; }

    }
}

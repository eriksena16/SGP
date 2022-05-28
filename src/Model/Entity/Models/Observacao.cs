using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    public class Observacao : BaseEntity
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public long UsuarioId { get; set; }
        public long EquipamentoId { get; set; }
        [JsonIgnore]
        [ForeignKey("EquipamentoId")]
        public Equipamento Equipamento { get; set; }
    }
}

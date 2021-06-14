using System;

namespace SGP.Model.Entity.DTO
{
    class EquipmentDTO
    {
        public long EquipmentId { get; set; }
        public long PatrimonyNumber { get; set; }
        public int ItemCategoryId { get; set; }
        public int? Age { get; set; }
        public int AssetClassificationId { get; set; }
        public string NotaFiscalUrl { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataDeCompra { get; set; }
        public int EquipmentModelId { get; set; }
        public int ManufacturerId { get; set; }
        public string Serialnumber { get; set; }
        public Status Status { get; set; }
        public int EquipmentPersonId { get; set; }
        public int SectorId { get; set; }
        public ConservationState ConservationState { get; set; }
        public string Observation { get; set; }
    }
}

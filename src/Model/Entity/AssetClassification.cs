using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class AssetClassification
    {
        public int AssetClassificationId { get; set; }
        public string Name { get; set; }
        [Display(Name ="Taxa de depreciação")]
        public int DepreciationRate { get; set; }
        [Display(Name ="Vida Útil")]
        public int LifeSpan { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}

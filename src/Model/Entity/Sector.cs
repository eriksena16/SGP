using System.Collections.Generic;

namespace SGP.Model.Entity
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Name { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
    }
}

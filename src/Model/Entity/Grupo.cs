using System.Collections.Generic;

namespace SGP.Model.Entity
{
    class Grupo : BaseEntity
    {
        public ICollection<Usuario> Usuario { get; set; }
    }
}

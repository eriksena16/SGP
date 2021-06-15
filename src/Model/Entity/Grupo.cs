using System.Collections.Generic;

namespace SGP.Model.Entity
{
    class Grupo : GenericEntity
    {
        public ICollection<Usuario> Usuario { get; set; }
    }
}

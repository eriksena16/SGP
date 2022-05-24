using System.Collections.Generic;

namespace SGP.Model.Entity
{
   public class Grupo : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}

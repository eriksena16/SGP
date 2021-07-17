using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public class GenericEntity
    {
        public long ID { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}

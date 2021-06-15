using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    [Table("User")]
    public class Usuario : GenericEntity
    {
        [Display(Name = "Login")]
        public string Username { get; set; }
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
    }
}
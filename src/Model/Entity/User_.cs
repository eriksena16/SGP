using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    [Table("User")]
    public class User_ : GenericEntity
    {
        [Display(Name = "Login")]
        public string Username { get; set; }
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }
    }
}
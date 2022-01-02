using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{

    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        [Display(Name = "Login")]
        public string Username { get; set; }
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGP.Model.Entity
{
    [Table("User")]
    public class User_
    {
        public int UserId { get; set; }
        [Display(Name = "Login")]
        public string Username { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }
    }
}
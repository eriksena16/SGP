using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity.ViewModels
{
    public class CategoriaDoItemViewModel : BaseEntity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
    }
}

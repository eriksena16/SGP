using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class EmpresaViewModel : GenericEntity
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(15, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 15)]
        public string Cnpj { get; set; }
        public int Cep { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        public string UF { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

    }
}

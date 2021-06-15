using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class Empresa : GenericEntity
    {
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
        public string Email { get; set; }

    }
}

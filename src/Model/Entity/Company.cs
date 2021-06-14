using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class Company : GenericEntity
    {
        public string Cnpj { get; set; }
        public int Cep { get; set; }
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        public string UF { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}

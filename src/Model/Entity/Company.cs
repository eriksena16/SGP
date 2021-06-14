using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class Company
    {
        public int CompanyId { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public int Cep { get; set; }
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}

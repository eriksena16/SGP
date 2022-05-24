using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class Empresa : BaseEntity
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}

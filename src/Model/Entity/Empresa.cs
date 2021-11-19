using System.ComponentModel.DataAnnotations;

namespace SGP.Model.Entity
{
    public abstract class Empresa : GenericEntity
    {
        public string Cnpj { get; set; }
        public int Cep { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}

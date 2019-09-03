using Senai.Ekips.WebApi.Domains;

namespace Senai.AutoPecas.WebApi.Domains
{
    public class FornecedoresDomain
    {
        public int IdFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int IdUsuario { get; set; }
        public UsuariosDomain Usuario { get; set; }

    }
}
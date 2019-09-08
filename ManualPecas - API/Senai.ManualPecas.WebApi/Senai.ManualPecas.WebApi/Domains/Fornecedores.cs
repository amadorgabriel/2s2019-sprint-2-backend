using System;
using System.Collections.Generic;

namespace Senai.ManualPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public int IdFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}

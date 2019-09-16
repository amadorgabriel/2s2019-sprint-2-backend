using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.ManualPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public int IdFornecedor { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string NomeFantasia { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}

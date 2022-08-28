using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        [Required (ErrorMessage = "O nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é necessário")]
        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}

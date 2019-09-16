using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Domains
{
    public partial class FornecedorPeca
    {
        [Required]
        public int IdFornecedor { get; set; }
        [Required]
        public int IdPeca { get; set; }
        [Required]
        public float Peso { get; set; }
    }
}



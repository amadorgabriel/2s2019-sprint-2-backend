using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.ManualPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPeca { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public float Peso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Senai.ManualPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPeca { get; set; }
        public string Descricao { get; set; }
        public float Peso { get; set; }
        public float Preco { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        [Required (ErrorMessage = "O titulo é necessário")]
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        public GeneroDomain Genero { get; set; }
    }
}

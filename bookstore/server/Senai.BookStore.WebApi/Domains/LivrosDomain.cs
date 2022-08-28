using System.ComponentModel.DataAnnotations;
using Senai.BookStore.WebApi.Domains;

namespace Senai.BookStore.WebApi.Controllers
{
    public class LivrosDomain
    {
        public int IdLivro { get; set; }

        [Required (ErrorMessage = "O titulo é necessário")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }
        
        [Required (ErrorMessage = "O autor é necessário")]
        public int IdAutor { get; set; }
        public AutoresDomain Autor {get; set;} 

        [Required (ErrorMessage = "O genero é necessário")]
        public int IdGenero { get; set; }
        public GenerosDomain Genero { get; set; }

    }
}
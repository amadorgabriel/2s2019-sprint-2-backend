using System.ComponentModel.DataAnnotations;

namespace Senai.BookStore.WebApi.Domains
{
    public class GenerosDomain
    {
        public int IdGenero { get; set; }
        [Required (ErrorMessage = "O nome é necessário")]
        public string Nome { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.BookStore.WebApi.Domains
{
    public class AutoresDomain
    {
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "O nome é necessário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é necessário")]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
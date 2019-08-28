using System.ComponentModel.DataAnnotations;

namespace Senai.Optus.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
using System;
using System.Linq;
using System.Security.Claims;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModels;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public EkipsContext ctx = new EkipsContext();

        public Usuarios BuscarPorEmailSenha(LoginViewModel login)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);   
        }

    }
}
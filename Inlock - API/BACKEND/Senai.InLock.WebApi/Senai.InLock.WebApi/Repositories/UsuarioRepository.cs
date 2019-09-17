using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public InlockContext ctx = new InlockContext();

        public Usuarios BuscarPorEmailSenha(LoginViewModel login)
        {
            Usuarios UserRetun = ctx.Usuarios.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);
            return UserRetun;
        }
    }
}

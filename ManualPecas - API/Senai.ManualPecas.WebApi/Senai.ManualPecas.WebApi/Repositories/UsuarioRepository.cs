using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioInterface
    {

        ManualPecasContext ctx = new ManualPecasContext();

        public Usuarios BuscarPorEmailSenha(LoginViewModel logon)
        {
            Usuarios userReturn = ctx.Usuarios.FirstOrDefault(u => u.Email == logon.Email && u.Senha == logon.Senha);
            return userReturn;
        }
    }
}

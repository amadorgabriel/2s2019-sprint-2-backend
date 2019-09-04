using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {

        AutoPecasContext ctx = new AutoPecasContext();

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            Usuarios userReturn = ctx.Usuarios.FirstOrDefault(user => user.Email == login.Email && user.Senha == user.Senha);
            return userReturn;
        }


    }
}

using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public List<Usuarios> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Usuarios.ToList();
            }
            
        }

    }
}

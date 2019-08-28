using Senai.Optus.WebApi.Domains;
<<<<<<< HEAD
using Senai.Optus.WebApi.ViewModels;
=======
>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
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
<<<<<<< HEAD
            }   
        }

        public Usuarios BuscarPorEmail(LoginViewModel user){
            using(OptusContext ctx = new OptusContext()){
                Usuarios userRec = ctx.Usuarios.FirstOrDefault( x => x.Email == user.Email && x.Senha == user.Senha );
                if(userRec == null){
                    return null;
                }
                return userRec;
            }
        }
=======
            }
            
        }

>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
    }
}

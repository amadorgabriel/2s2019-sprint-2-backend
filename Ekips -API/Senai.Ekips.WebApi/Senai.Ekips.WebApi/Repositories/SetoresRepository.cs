using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class SetoresRepository
    {

        public List<Setores> Listar()
        {
            EkipsContext ctx = new EkipsContext();
            return ctx.Setores.ToList();
        }

        public Setores BuscarPorId( int id)
        {
            EkipsContext ctx = new EkipsContext();
            Setores setorRetorndo = ctx.Setores.Find(id);
            return setorRetorndo;
        }

        public void Cadastrar(Setores setor)
        {
            EkipsContext ctx = new EkipsContext();
            ctx.Setores.Add(setor);
            ctx.SaveChanges();
        }

    }
}

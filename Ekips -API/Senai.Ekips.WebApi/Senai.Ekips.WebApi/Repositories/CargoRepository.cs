using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public EkipsContext ctx = new EkipsContext();
        public List<Cargos> Listar()
        {
            return ctx.Cargos.ToList();
        }

        public Cargos BuscarPorId(int id){
            return ctx.Cargos.Find(id);
        }

        public void Cadastrar(Cargos cargo){
            ctx.Cargos.Add(cargo);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Cargos cargo){
            Cargos cargoReturn = ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            cargoReturn.Nome = cargo.Nome;
            cargoReturn.Ativo = cargo.Ativo;
            ctx.SaveChanges();
        }
    }
}

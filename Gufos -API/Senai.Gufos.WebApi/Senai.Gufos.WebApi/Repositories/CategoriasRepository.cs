using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriasRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorId(int Id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == Id); // Não é necessário ser um Id (int) pode ser alguma String ou sla
            }
        }

        public void Deletar(int Id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoria = ctx.Categorias.Find(Id);  // É necessário ser um Id (int)
                ctx.Categorias.Remove(categoria);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoriaRetornada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                //UPDATE categorias set Nome = @Nome
                categoriaRetornada.Nome = categoria.Nome;
                //INSERT - ADD, DELETE - REMOVE, UPDATE - UPDATE
                ctx.Categorias.Update(categoriaRetornada);
                ctx.SaveChanges();     
            }
        }
    }
}

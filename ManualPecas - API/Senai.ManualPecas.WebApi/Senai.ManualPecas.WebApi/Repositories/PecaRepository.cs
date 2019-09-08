using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class PecaRepository : IPecasInterface
    {

        public ManualPecasContext ctx = new ManualPecasContext();

        public void Atualizar(int id, Pecas peca)
        {
            Pecas pecaReturn = ctx.Pecas.FirstOrDefault(p => p.IdPeca == id);
            pecaReturn.IdPeca = peca.IdPeca;
            pecaReturn.Peso = peca.Peso;
            pecaReturn.Descricao = peca.Descricao;
            pecaReturn.Preco = peca.Preco;
            ctx.SaveChanges();
        }

        public void Cadastrar(Pecas peca)
        {
            ctx.Add(peca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pecas pecaReturn= ctx.Pecas.Find(id);
            ctx.Remove(pecaReturn);
            ctx.SaveChanges();
        }

        public List<Pecas> ListarTodas()
        {
            return ctx.Pecas.ToList();
        }
    }
}

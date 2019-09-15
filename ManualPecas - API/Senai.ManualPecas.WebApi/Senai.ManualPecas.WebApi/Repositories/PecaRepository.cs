using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class PecaRepository : IPecaInterface
    {
        public ManualPecasContext db = new ManualPecasContext();
        
        public void Atualizar(int id, Pecas peca)
        {
            Pecas pecaReurn = db.Pecas.Find(id);
            pecaReurn.Descricao = peca.Descricao;
            pecaReurn.Peso = peca.Peso;
            db.SaveChanges();
        }

        public void Cadastrar(Pecas peca)
        {
            db.Pecas.Add(peca);
            db.SaveChanges();
        }

        public void Deletar(int id)
        {
            db.Pecas.Remove(db.Pecas.Find(id));
            db.SaveChanges();
        }

        public List<Pecas> ListarTodas()
        {
            return db.Pecas.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        public List<Estudios> Listar()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }

        public void Cadastrar(Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Estudios Estudio = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(Estudio);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
               return ctx.Estudios.First(x => x.EstudioId == id);
            }
        }

        public void Atualizar (Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.First(x => x.EstudioId == estudio.EstudioId);
                EstudioBuscado.NomeEstudio = estudio.NomeEstudio;
                EstudioBuscado.DataCriacao = estudio.DataCriacao;
                EstudioBuscado.PaisOrigem = estudio.PaisOrigem;
                ctx.Estudios.Update(EstudioBuscado);
                ctx.SaveChanges();
            }
        }
        public Estudios BuscarPorNome(string nome)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).First(x => x.NomeEstudio == nome);
            }
        }

        public List<Estudios> BuscarPorPais(string pais)
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Estudios.Where(x => x.PaisOrigem == pais).ToList();
            }
        }
    }
}

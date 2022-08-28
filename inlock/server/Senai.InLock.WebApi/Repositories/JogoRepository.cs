using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {

        public InlockContext ctx = new InlockContext();

        public List<Jogos> ListarJogos()
        {
            return ctx.Jogos.ToList();
        }

        public void Cadastrar(Jogos game)
        {
            ctx.Jogos.Add(game);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Jogos joj)
        {
            Jogos gameRetornado = ctx.Jogos.FirstOrDefault(jogo => jogo.JogoId == id);
            gameRetornado.JogoId = joj.JogoId;
            gameRetornado.NomeJogo = joj.NomeJogo;
            gameRetornado.Valor = joj.Valor;
            gameRetornado.EstudioId = joj.EstudioId;
            gameRetornado.DataLancamento = joj.DataLancamento;
            gameRetornado.Descricao = joj.Descricao;
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos gameRetornado = ctx.Jogos.Find(id);
            ctx.Jogos.Remove(gameRetornado);
            ctx.SaveChanges();
        }

        public Jogos BuscarPorNome(string nome)
        {
            Jogos gameReturn = ctx.Jogos.FirstOrDefault(y => y.NomeJogo == nome);
            return gameReturn;
        }

        public List<Jogos> VisualizarTudo()
        {
            List<Jogos> jogosReturnLs = ctx.Jogos.Include(x => x.Estudio).ToList();
            return jogosReturnLs;
        }

        public List<Jogos> BuscarMaisCaros()
        {

            var Ls = ctx.Jogos.FromSql("Select Top(5)* From Jogos Order By Valor DESC").ToList();
            return Ls;
        }

        public List<Jogos> BuscarMaisRecentes()
        {
            var Ls = ctx.Jogos.FromSql("select * from Jogos ORDER BY DataLancamento DESC").ToList();
            return Ls;
        }





    }
}

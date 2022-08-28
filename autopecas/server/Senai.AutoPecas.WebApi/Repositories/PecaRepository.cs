using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository : IPecasRepository
    {
        public AutoPecasContext ctx = new AutoPecasContext();

        public void Atualizar(int Id, Pecas peca)
        {
            Pecas pecaReturn = ctx.Pecas.FirstOrDefault(p => p.IdPeca == Id);
            pecaReturn.CodigoPeca = peca.CodigoPeca;
            pecaReturn.Descricao = peca.Descricao;
            pecaReturn.IdFornecedor = peca.IdFornecedor;
            pecaReturn.Peso = peca.Peso;
            pecaReturn.PrecoCusto = pecaReturn.PrecoCusto;
            pecaReturn.PrecoVenda = pecaReturn.PrecoVenda;
            ctx.SaveChanges();
        }

        public Pecas BuscarPorId(int id)
        {
            return ctx.Pecas.Find(id);
        }

        public void Cadastrar(Pecas peca)
        {
            ctx.Pecas.Add(peca);
            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Pecas pecaReturn = ctx.Pecas.Find(Id);
            ctx.Pecas.Remove(pecaReturn);
            ctx.SaveChanges();
        }

        public List<Pecas> Listar(Fornecedores fornecedor)
        {
            return ctx.Pecas.FromSql("SELECT * FROM Pecas WHERE IdFornecedor =" + fornecedor.IdFornecedor).ToList();
        }

        public string MostrarLucro()
        {
           // listar todas
           //while lista eu armazeno
           //depois soma tudo
           //divide pelo nº de pecas

           float PCustoTotal = 0;
           float PVendaTotal = 0;
           int vezes = 0;

           foreach (var peca in ctx.Pecas.ToList())
           {
                PCustoTotal += peca.PrecoCusto;
                PVendaTotal += peca.PrecoVenda;
                vezes ++;
           }

           float valorGanho = PVendaTotal / PCustoTotal;
           float lucro = PVendaTotal - PCustoTotal;
           float porcentagem = lucro / vezes;
           return $"O valor de ganho da empresa AutoPecas é de {valorGanho} a diferença em reais é de {lucro}, e em porcentagem o lucro equivale a {porcentagem}%";

        }
    }
}

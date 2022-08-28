using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public AutoPecasContext ctx = new AutoPecasContext();

        public Fornecedores BuscarPorIdUsuario(int id)
        {
            Fornecedores fornecedor = ctx.Fornecedores.FirstOrDefault(f => f.IdUsuario == id);
            return fornecedor;
        }

        public List<Fornecedores> ListarDados()
        {
            return ctx.Fornecedores.Include(f => f.Pecas).ToList();
        }
    }
}

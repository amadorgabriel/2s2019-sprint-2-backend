using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorInterface
    {

        public ManualPecasContext db = new ManualPecasContext();

        public void Cadastrar(Fornecedores forn)
        {
            db.Fornecedores.Add(forn);
            db.SaveChanges();
        }

        public Fornecedores TrazerFornecedorPorIdUser(int idUser)
        {
            Fornecedores fornReturn = db.Fornecedores.First(f => f.IdUsuario == idUser);
            return fornReturn;
        }
    }
}

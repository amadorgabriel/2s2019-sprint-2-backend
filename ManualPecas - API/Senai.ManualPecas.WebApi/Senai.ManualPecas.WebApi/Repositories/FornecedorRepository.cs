using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorInterface
    {
        ManualPecasContext db = new ManualPecasContext();

        public Fornecedores Buscar(LoginViewModel logon)
        {
            Fornecedores fornReturn = db.Fornecedores.FirstOrDefault(f => f.Cnpj == logon.Cnpj && f.Senha == logon.Senha);
            
            return fornReturn;
        }

        public Fornecedores BuscarPorId(int id)
        {
            Fornecedores f = db.Fornecedores.Find(id);
            return f;
        }

        public void CadastrarFornecedor(Fornecedores fornecedor)
        {
            db.Fornecedores.Add(fornecedor);
            db.SaveChanges();
        }

        public List<Fornecedores> ListarFornecedores()
        {
            return db.Fornecedores.ToList();
        }

    }
}

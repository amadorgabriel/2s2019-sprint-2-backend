using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IFornecedorRepository
    {
        Fornecedores BuscarPorIdUsuario(int id);
        List<Fornecedores> ListarDados();
    }
}

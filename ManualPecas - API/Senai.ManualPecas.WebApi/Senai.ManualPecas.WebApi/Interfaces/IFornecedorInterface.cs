using Senai.ManualPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Interfaces
{
    public interface IFornecedorInterface
    {
        void Cadastrar(Fornecedores forn);
        Fornecedores TrazerFornecedorPorIdUser(int idUser);
    }
}

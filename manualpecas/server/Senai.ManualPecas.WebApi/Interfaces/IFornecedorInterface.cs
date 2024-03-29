﻿using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Interfaces
{
    public interface IFornecedorInterface
    {
        Fornecedores Buscar(LoginViewModel logon);
        List<Fornecedores> ListarFornecedores();
        void CadastrarFornecedor(Fornecedores f );
        Fornecedores BuscarPorId(int id);
    }
}

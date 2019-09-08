using Senai.ManualPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Interfaces
{
    public interface IPecasInterface
    {
        List<Pecas> ListarTodas();
        void Cadastrar(Pecas peca);
        void Atualizar(int id, Pecas peca);
        void Deletar(int id);
    }
}

using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecasRepository
    {
        List<Pecas> Listar();
        Pecas BuscarPorId(int id);
        void Cadastrar(Pecas peca);
        void Atualizar(int Id, Pecas peca);
        void Deletar(int Id);
    }
}

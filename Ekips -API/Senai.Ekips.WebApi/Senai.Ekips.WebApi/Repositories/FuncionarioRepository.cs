using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        public List<Funcionarios> Listar()
        {
            EkipsContext ctx = new EkipsContext();
            return ctx.Funcionarios.ToList();
        }

        public void Cadastrar (Funcionarios func)
        {
            EkipsContext ctx = new EkipsContext();
            ctx.Funcionarios.Add(func);
            ctx.SaveChanges();
        }

        public void Atualizar (int id, Funcionarios func)
        {
            EkipsContext ctx = new EkipsContext();
            Funcionarios funcRetornado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            funcRetornado.Nome = func.Nome;
            funcRetornado.Cpf = func.Cpf;
            funcRetornado.DataNascimento = func.DataNascimento;
            funcRetornado.Salario = func.Salario;
            funcRetornado.IdCargo = func.IdCargo;
            funcRetornado.IdSetor = func.IdSetor;
            funcRetornado.IdUsuario = func.IdUsuario;

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            EkipsContext ctx = new EkipsContext();
            Funcionarios funcRetornado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            ctx.Remove(funcRetornado);
            ctx.SaveChanges();
        }
    }
}

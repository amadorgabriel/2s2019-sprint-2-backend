using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        string StringConnection = "Data Source=.\\SqlExpress; Initial Catalog=T_Ekips;User Id=sa;Pwd=132";

        public List<Funcionarios> Listar()
        {
            //Ao trazer os funcionários, apresentar também os cargos e os devdios departamentos
            // EkipsContext ctx = new EkipsContext();
            // return ctx.Funcionarios.Include(func => func.IdCargoNavigation).Include(func => func.IdSetorNavigation).ToList();

            List<Funcionarios> funcLs = new List<Funcionarios>();

            SqlConnection con = new SqlConnection(StringConnection);
            con.Open();
            string Query = "SELECT Funcionarios.IdFuncionario, Funcionarios.Nome, Funcionarios.Cpf, Funcionarios.DataNascimento, Funcionarios.Salario, Cargos.IdCargo, Cargos.Nome as NomeCargo, Cargos.Ativo, Setores.IdSetor, Setores.Nome as NomeSetor FROM Funcionarios JOIN Cargos ON Funcionarios.IdCargo = Cargos.IdCargo JOIN Setores ON Funcionarios.IdSetor = Setores.IdSetor";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Console.WriteLine("AAA");

                    Funcionarios func = new Funcionarios
                    {
                        IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                        Nome = sdr["Nome"].ToString(),
                        Cpf = sdr["Cpf"].ToString(),
                        DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                        Salario = Convert.ToInt32(sdr["Salario"]),
                        IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                        IdSetor = Convert.ToInt32(sdr["IdSetor"]),
                        IdCargoNavigation = new Cargos
                        {
                            IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                            Nome = sdr["NomeCargo"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"])
                        },
                        IdSetorNavigation = new Setores
                        {
                            IdSetor = Convert.ToInt32(sdr["IdSetor"]),
                            Nome = sdr["NomeSetor"].ToString()
                        }
                    };
                    funcLs.Add(func);
                }
            }

            return funcLs;

        }

        public void Cadastrar(Funcionarios func)
        {
            EkipsContext ctx = new EkipsContext();
            ctx.Funcionarios.Add(func);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Funcionarios func)
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

using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        //string StringConnection = "Data Source=.\\SqlExpress; Initial Catalog=T_Ekips;User Id=sa;Pwd=132";
        string StringConnection = "Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_Ekips;Integrated Security=SSPI;";

        public List<Funcionarios> Listar()
        {
            EkipsContext ctx = new EkipsContext();
            return ctx.Funcionarios.Include(func => func.IdCargoNavigation).Include(func => func.IdSetorNavigation).ToList();
        }

        public Funcionarios BuscarPorId(int id)
        {
            EkipsContext ctx = new EkipsContext();
            return ctx.Funcionarios.Find(id);

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


        public List<Funcionarios> BuscarPorSalarioIgualOuMaior(int valor)
        {

            var funcLs = new List<Funcionarios>();

            SqlConnection con = new SqlConnection(StringConnection);
            string Query = "SELECT Funcionarios.IdFuncionario, Funcionarios.Nome, Funcionarios.Cpf, Funcionarios.DataNascimento, Funcionarios.Salario FROM Funcionarios WHERE Salario >= @Valor";
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Valor", valor);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Funcionarios func = new Funcionarios
                {
                    IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                    Nome = sdr["Nome"].ToString(),
                    Cpf = sdr["Cpf"].ToString(),
                    DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                    Salario = Convert.ToInt32(sdr["Salario"]),
                };
                funcLs.Add(func);
            }
            return funcLs;

        }

        // public List<Funcionarios> BuscarEntidadeFuncionario (string ordem)
        // {
        //     var funcLs = new List<Funcionarios>();

        //     SqlConnection con = new SqlConnection(StringConnection);
        //     string Query = "SELECT * FROM Funcionarios ORDER BY IdFuncionario @ordem";
        //     con.Open();
        //     SqlCommand cmd = new SqlCommand(Query, con);
        //     cmd.Parameters.AddWithValue("@ordem", ordem);
        //     SqlDataReader sdr = cmd.ExecuteReader();

        //     while (sdr.Read())
        //     {
        //         Funcionarios func = new Funcionarios
        //         {
        //             IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
        //             Nome = sdr["Nome"].ToString(),
        //             Cpf = sdr["Cpf"].ToString(),
        //             DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
        //             Salario = Convert.ToInt32(sdr["Salario"]),
        //         };
        //         funcLs.Add(func);
        //     }
        //     return funcLs;

        // }

    }
}

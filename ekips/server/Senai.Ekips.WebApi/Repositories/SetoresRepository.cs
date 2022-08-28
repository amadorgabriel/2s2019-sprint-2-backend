using Microsoft.AspNetCore.Authorization;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class SetoresRepository
    {
        //string StringConnection = "Data Source=.\\SqlExpress; Initial Catalog=T_Ekips;User Id=sa;Pwd=132";
        string StringConnection = "Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_Ekips;Integrated Security=SSPI;";
        public EkipsContext ctx = new EkipsContext();
        public List<Setores> Listar()
        {
            return ctx.Setores.ToList();
        }

        public Setores BuscarPorId(int id)
        {
            Setores setorRetorndo = ctx.Setores.Find(id);
            return setorRetorndo;
        }

        public void Cadastrar(Setores setor)
        {
            ctx.Setores.Add(setor);
            ctx.SaveChanges();
        }

        public List<Funcionarios> ListarFuncionariosPorIdDepartamento(int id)
        {

            var funcLs = new List<Funcionarios>();
            string Query = "SELECT * FROM Funcionarios WHERE IdSetor = @Id";

            SqlConnection con = new SqlConnection(StringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Id", id);
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
                    IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                    IdSetor = Convert.ToInt32(sdr["IdSetor"]),
                    IdUsuario = Convert.ToInt32(sdr["IdUsuario"])
                };
                funcLs.Add(func);
            }
            return funcLs;

        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        //string StringConnection = "Data Source=.\\SqlExpress; Initial Catalog=T_Ekips;User Id=sa;Pwd=132";
        string StringConnection = "Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_Ekips;Integrated Security=SSPI;";

        public EkipsContext ctx = new EkipsContext();
        public List<Cargos> Listar()
        {
            return ctx.Cargos.ToList();
        }

        public Cargos BuscarPorId(int id)
        {
            return ctx.Cargos.Find(id);
        }

        public void Cadastrar(Cargos cargo)
        {
            ctx.Cargos.Add(cargo);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Cargos cargo)
        {
            Cargos cargoReturn = ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            cargoReturn.Nome = cargo.Nome;
            cargoReturn.Ativo = cargo.Ativo;
            ctx.SaveChanges();
        }

        public List<Funcionarios> ListarFuncionariosPorIdCargo(int id)
        {
            var funcLs = new List<Funcionarios>();
            string Query = "SELECT * FROM Funcionarios WHERE IdCargo = @Id ";

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

        public List<Funcionarios> BuscarFuncionariosPorNomeCargo(string nome)
        {
            var funcLs = new List<Funcionarios>();

            SqlConnection con = new SqlConnection(StringConnection);
            string Query = "SELECT Funcionarios.IdFuncionario, Funcionarios.Nome, Funcionarios.Cpf, Funcionarios.DataNascimento, Funcionarios.Salario, Cargos.IdCargo, Cargos.Nome as NomeCargo, Cargos.Ativo FROM Funcionarios JOIN Cargos ON Funcionarios.IdCargo = Cargos.IdCargo WHERE Cargos.Nome LIKE '%@Nome%'";
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
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
                    IdCargoNavigation = new Cargos
                    {
                        IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                        Nome = sdr["NomeCargo"].ToString(),
                        Ativo = Convert.ToBoolean(sdr["Ativo"])
                    }
                };
                funcLs.Add(func);
            }
            return funcLs;
        }

        public List<Cargos> BuscarCargosAtivos()
        {
            var cargosLs = new List<Cargos>();

            SqlConnection con = new SqlConnection(StringConnection);
            string Query = "SELECT * FROM Cargos WHERE Ativo = 1 ORDER BY IdCargo";
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Cargos cargo = new Cargos
                {
                    IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                    Nome = sdr["Nome"].ToString(),
                    Ativo = Convert.ToBoolean(sdr["Ativo"])
                };
                cargosLs.Add(cargo);
            }
            return cargosLs;
        }





    }
}

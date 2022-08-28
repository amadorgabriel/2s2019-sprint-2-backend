using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepositorio
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();
            //estabelecer conexão
            //abrir ela
            //criar lista de funcionarios
            //criar query
            //criar command
            //armazenar no sdr
            //criar loop de armazenamento convertido

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                conexao.Open();
                string Query = "SELECT * FROM Funcionarios";

                using (SqlCommand command = new SqlCommand(Query, conexao))
                {
                    SqlDataReader sdr = command.ExecuteReader();
                    while (sdr.Read()) // enquanto está lendo
                    {
                        //ARMAZENAR NO DOMAIN
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = (sdr["Sobrenome"]).ToString()
                        };

                        funcionarios.Add(funcionario);

                    }
                }
            }
            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int Id)
        {
            //criar con
            //abrir con
            //using cmd
            FuncionarioDomain funcionarioReturn = new FuncionarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "SELECT * FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", Id); // condição
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = (sdr["Nome"]).ToString(),
                                Sobrenome = (sdr["Sobrenome"]).ToString()
                            };
                            return funcionario;
                        };
                    }
                    return null; // caso não houver
                }
            }
        }

        public void Cadastrar (FuncionarioDomain func)
        {
            // criar con
            // abrir con
            // criar query
            // executar comando

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome, @DataNacimento)";
                con.Open();
                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", func.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", func.Sobrenome);
                    cmd.Parameters.AddWithValue("@DataNacimento", func.DataNascimento);

                    sdr = cmd.ExecuteReader();
                }
            }

        }

        public void Deletar (int id)
        {          
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);

                SqlDataReader sdr = cmd.ExecuteReader();
            }
        }

        public void Atualizar(int id, FuncionarioDomain func)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "UPDATE Funcionarios SET Nome = @Nome , Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                cmd.Parameters.AddWithValue("@Nome", func.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", func.Sobrenome);

                SqlDataReader sdr = cmd.ExecuteReader();
            }
        }
    }
}

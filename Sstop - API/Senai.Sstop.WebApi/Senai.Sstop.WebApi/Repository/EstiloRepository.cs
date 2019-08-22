using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        // aonde que será feita essa comunicação
          private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";
        // private string StringConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=T_SStop;Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01";  
        
        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();
            // chamar o banco passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // código dB
                string Query = "SELECT IdEstilosMusical, Nome FROM EstilosMusicas"; 
                con.Open();        // abrir a conexao
                SqlDataReader sdr;

                // comando a ser executado em qual conexao
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // pegar os valores da tabela do banco e armazenar dentro do SDR do backend
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(sdr["IdEstilosMusical"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }

            }
            // executar o select
            // retornar as informacoes
            return estilos;
        }

          // criar um método para que eu acesse o banco de dados e busque o estilo musical aonde o id seja igual ao que eu quero pq eu mando
        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdEstilosMusical, Nome FROM EstilosMusicas WHERE IdEstilosMusical = @IdEstilosMusical";
            // abrir a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstilosMusical", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        // ler o que tem no sdr
                        while(sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstilosMusical"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                    return null;
                    // retornar
                }
            }
        }

        public void Cadastrar(EstiloDomain estiloDomain)
        {
            string Query = "INSERT INTO EstilosMusicas (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar (int id){
            string Query = "DELETE FROM EstilosMusicas WHERE IdEstilosMusical = @Id";

            using(SqlConnection con = new SqlConnection(StringConexao))
            { 
                 using (SqlCommand cmd = new SqlCommand(Query, con)) 
                 {
                      cmd.Parameters.AddWithValue("@Id", id);
                      con.Open();
                      cmd.ExecuteNonQuery();
                 }
            }
        }

        
        public void Atualizar( EstiloDomain estiloDomain){
            string Query = "UPDATE EstilosMusicais SET Nome = @Nome WHERE IdEstilosMusical = @Id";
            
            // estabelecer conecção
            // comando
            // abrir conexão

            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                SqlCommand comando = new SqlCommand(Query, con);
                comando.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                comando.Parameters.AddWithValue("@Id", estiloDomain.IdEstilo);

                con.Open();
                comando.ExecuteNonQuery();
            }
        }




    }
}

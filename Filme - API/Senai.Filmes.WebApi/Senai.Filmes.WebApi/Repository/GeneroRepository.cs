using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_RoteiroFilmes;User Id=sa;Pwd=132;";
        // private string StringConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RoteiroFilmes;Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            //Listar
            //criar conexão
            //abrir con
            //armazenar o dado do db
            //retornar

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos";
                conexao.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, conexao))
                {
                    // pegar os valores da tabela do banco e armazenar dentro da aplicacao do backend
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GeneroDomain estilo = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(estilo);
                    }
                }
            }
            return generos;
        }
    
        public GeneroDomain BuscarPorId(int id){ // Basicamente um SELECT com WHERE
            //Buscar
            //Criar conexão para acessar dB
            //abrir Conexão
            //criar query do comando no db
            //using comando (query , conexao)
            //definir parametro onde @id = id
            // criar sdr que armazena os dados do dB
            // criar loop que armazenará cada linha numa classeDomain onde irá
                //- Criar o Domain
                //- Atribuir os valores das linhas das tabelas dB a um domain
                //- Converter os dados sdr, até toString();
            //retornar Domain

            using(SqlConnection conexao = new SqlConnection(StringConexao)){
                conexao.Open();
                string Query = "SELECT * FROM Generos WHERE IdGenero = @Id";

                using(SqlCommand command = new SqlCommand(Query, conexao)){

                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader sdr = command.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain{
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }

        }
    
        public void Cadastrar(GeneroDomain generoDomain){
            //criar conexão com dB
            //abrir conexão com dB
            //criar query do comando dB
            //criar comando (query, conexao)
            //definir parametros
            //executar
            
            using(SqlConnection conexao = new SqlConnection(StringConexao)){
                conexao.Open();
                string Query = "INSERT INTO Generos(Nome) VALUES (@Nome)";

                using(SqlCommand command = new SqlCommand(Query, conexao)){
                    command.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                    command.ExecuteNonQuery(); // Não sei para que serve
                }
            }

        }
   
        public void Deletar(int id){
            //criar conexao
            //abrir conexao
            //crio a query
            //CRIAR PARAMETROS
            //crio using comando
            //executo comando

            using(SqlConnection conexao = new SqlConnection(StringConexao)){
                conexao.Open();
                string Query = "DELETE FROM Generos WHERE IdGenero = @Id";

                using(SqlCommand command = new SqlCommand(Query, conexao)){
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
   
        public void Atualizar (int id, GeneroDomain genero)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @Id;";
                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    sdr = cmd.ExecuteReader();
                }
            }
        }
    }
}
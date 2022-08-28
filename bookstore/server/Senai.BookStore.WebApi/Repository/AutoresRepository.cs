using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.BookStore.WebApi.Controllers;
using Senai.BookStore.WebApi.Domains;

namespace Senai.BookStore.WebApi.Repository
{
    public class AutoresRepository
    {
        // private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";
        private string StringConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=T_BookStore;Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01";

        public List<AutoresDomain> ListarTodos()
        {

            List<AutoresDomain> autoresLs = new List<AutoresDomain>();

            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "SELECT * FROM Autores ORDER BY IdAutor ASC";

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    AutoresDomain autor = new AutoresDomain
                    {
                        IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                        Nome = sdr["Nome"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Ativo = Convert.ToBoolean(sdr["Ativo"]),
                        DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]).Date
                    };
                    autoresLs.Add(autor);
                }
            }
            return autoresLs;
        }

        public void Cadastrar(AutoresDomain autor)
        {
            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "INSERT INTO Autores (Nome, Email, Ativo, DataNascimento) VALUES (@Nome, @Email, @Ativo, @DataNascimento)";
            SqlDataReader sdr;
            int ativo;

            if (autor.Ativo == false)
            {
                ativo = 0;
            }
            else
            {
                ativo = 1;
            }

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@Nome", autor.Nome);
            command.Parameters.AddWithValue("@Email", autor.Email);
            command.Parameters.AddWithValue("@Ativo", ativo);
            command.Parameters.AddWithValue("@DataNascimento", autor.DataNascimento);

            sdr = command.ExecuteReader();
        }

        public List<LivrosDomain> BuscarLivroPorIdAutor(int id)
        {
            List<LivrosDomain> livrosLs = new List<LivrosDomain>();

            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Livros.IdAutor = @IdAutor";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@IdAutor", id);
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    LivrosDomain livro = new LivrosDomain
                    {
                        IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                        Titulo = sdr["Titulo"].ToString(),
                        Descricao = sdr["Descricao"].ToString(),
                        IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                        Autor = new AutoresDomain
                        {
                            IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                            Nome = sdr["Nome"].ToString(),
                            Email = sdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(sdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]).Date
                        },
                        IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                        Genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        }
                    };
                    livrosLs.Add(livro);
                }
            }
            return livrosLs;
        }

   
    }
}

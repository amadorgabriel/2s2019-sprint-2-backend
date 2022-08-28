using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.BookStore.WebApi.Controllers;
using Senai.BookStore.WebApi.Domains;

namespace Senai.BookStore.WebApi.Repository
{
    public class LivrosRepository
    {
        // private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";
        private string StringConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=T_BookStore;Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01";

        public List<LivrosDomain> ListarTodos()
        {
            List<LivrosDomain> livrosLs = new List<LivrosDomain>();

            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero";

            SqlCommand cmd = new SqlCommand(Query, con);
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

        public void Cadastrar(LivrosDomain livro)
        {
            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "INSERT INTO Livros(Titulo, Descricao, IdAutor, IdGenero) VALUES (@Titulo, @Descricao, @IdAutor, @IdGenero)";
            SqlDataReader sdr;

            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@Titulo", livro.Titulo);
            command.Parameters.AddWithValue("@Descricao", livro.Descricao);
            command.Parameters.AddWithValue("@IdAutor", livro.IdAutor);
            command.Parameters.AddWithValue("@IdGenero", livro.IdGenero);

            sdr = command.ExecuteReader();
        }

        public LivrosDomain BuscarPorId(int id)
        {

            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Livros.IdLivro = @Id";

            SqlCommand comando = new SqlCommand(Query, con);
            comando.Parameters.AddWithValue("@Id", id);
            SqlDataReader sdr = comando.ExecuteReader();

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
                return livro;
            }
            return null;
        }

        public void Atualizar(int id, LivrosDomain livro)
        {
            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "UPDATE Livros SET Titulo = @Titulo, Descricao = @Descricao, IdAutor = @IdAutor, IdGenero = @IdGenero WHERE IdLivro = @IdLivro";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Titulo", livro.Titulo);
            cmd.Parameters.AddWithValue("@Descricao", livro.Descricao);
            cmd.Parameters.AddWithValue("@IdAutor", livro.IdAutor);
            cmd.Parameters.AddWithValue("@IdGenero", livro.IdGenero);
            cmd.Parameters.AddWithValue("@IdLivro", id);

            SqlDataReader sdr = cmd.ExecuteReader();
        }

        public void Deletar(int id)
        {
            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "DELETE FROM Livros WHERE IdLivro = @IdLivro";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@IdLivro", id);

            SqlDataReader sdr = cmd.ExecuteReader();
        }

        









    }
}
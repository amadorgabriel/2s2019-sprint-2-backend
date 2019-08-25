using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.BookStore.WebApi.Controllers;
using Senai.BookStore.WebApi.Domains;
namespace Senai.BookStore.WebApi.Repository
{
    public class GenerosRepository
    {
        // private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore;User Id=sa;Pwd=132;";
        private string StringConexao = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=T_BookStore;Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01";

        public List<GenerosDomain> ListarTodos()
        {

            List<GenerosDomain> generosLs = new List<GenerosDomain>();

            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "SELECT * FROM Generos ORDER BY IdGenero ASC";

            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    GenerosDomain genero = new GenerosDomain
                    {
                        IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                        Nome = sdr["Nome"].ToString()
                    };
                    generosLs.Add(genero);
                }
            }
            return generosLs;
        }

        public void Cadastrar(GenerosDomain genero)
        {
            SqlConnection con = new SqlConnection(StringConexao);
            con.Open();
            string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";
            SqlDataReader sdr;

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Nome", genero.Nome);

            sdr = cmd.ExecuteReader();
        }

        // public List<LivrosDomain> BuscarLivrosPorNomeGenero(string nome)
        // {
        //     List<LivrosDomain> livrosLs = new List<LivrosDomain>();

        //     SqlConnection con = new SqlConnection(StringConexao);
        //     con.Open();
        //     string Query = "SELECT Livros.*, Generos.*, Autores.* FROM Livros JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero WHERE Generos.Nome LIKE '%@Nome%'";

        //     SqlCommand cmd = new SqlCommand(Query, con);
        //     cmd.Parameters.AddWithValue("@Nome", nome);

        //     SqlDataReader sdr = cmd.ExecuteReader();

        //     if (sdr.HasRows)
        //     {
        //         while (sdr.Read())
        //         {
        //             LivrosDomain livro = new LivrosDomain
        //             {
        //                 IdLivro = Convert.ToInt32(sdr["IdLivro"]),
        //                 Titulo = sdr["Titulo"].ToString(),
        //                 Descricao = sdr["Descricao"].ToString(),
        //                 IdAutor = Convert.ToInt32(sdr["IdAutor"]),
        //                 Autor = new AutoresDomain
        //                 {
        //                     IdAutor = Convert.ToInt32(sdr["IdAutor"]),
        //                     Nome = sdr["Nome"].ToString(),
        //                     Email = sdr["Email"].ToString(),
        //                     Ativo = Convert.ToBoolean(sdr["Ativo"]),
        //                     DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]).Date
        //                 },
        //                 IdGenero = Convert.ToInt32(sdr["IdGenero"]),
        //                 Genero = new GenerosDomain
        //                 {
        //                     IdGenero = Convert.ToInt32(sdr["IdGenero"]),
        //                     Nome = sdr["Nome"].ToString()
        //                 }
        //             };
        //             livrosLs.Add(livro);
        //         }
        //     }
        //     return livrosLs;
        // }
    }
}

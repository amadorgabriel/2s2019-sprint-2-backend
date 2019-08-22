using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "INSERT INTO Filmes(Titulo, IdGenero) VALUES (@Titulo, @Id)";
                SqlDataReader sql;

                using(SqlConnection con = SqlConnection(Query, con))
                {

                }

            }

        }
    }
}

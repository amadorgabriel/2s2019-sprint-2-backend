using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repository
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";


        public List<ArtistaDomain> Listar()
        {
            using(SqlConnection con = new SqlConnection(StringConexao) )
            {
                string Query = "SELECT A.IdArtista, A.Nome, E.IdEstiloMusical, E.Nome AS NomeEstilo FROM Artistas AS A INNER JOIN EstilosMusicais AS E ON A.IdEstiloMusical = E.IdEstiloMusical;";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain
                    }



                }
                
            }
        }
    }
}

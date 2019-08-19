using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repository
{
    public class EstiloRepository
    {
                                // 
        private string StringConexao = "Data Source=.\\SqlExpress;InitialCatalog=T/_Sstop;User Id=sa;Pwd=132";

        public List<EstiloDomain> Listar()
        {
            // Buscar dados do Banco
            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //Chamar o Banco de Dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Comando a ser executado
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicais";

                // Abrir connection
                con.Open();

                //Ler
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        EstiloDomain estilo = EstiloDomain{
                            IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"])
                            Nome = sdr["Nome"].ToString()
                        }
                        estilos.Add(estilo);
                    }
                }
                return  estilos 

            }

        }
    }
}

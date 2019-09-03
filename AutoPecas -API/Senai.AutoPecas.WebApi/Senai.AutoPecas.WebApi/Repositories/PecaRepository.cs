using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using Senai.AutoPecas.WebApi.Domains;
using Senai.Ekips.WebApi.Domains;

namespace Senai.Ekips.WebApi.Repositories
{
    public class PecaRepository
    {
        //string StringConnection = "Data Source=.\\SqlExpress; Initial Catalog=T_Ekips;User Id=sa;Pwd=132";

        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_AutoPecas;Integrated Security=SSPI;");

        public List<PecasDomain> Listar()
        {
            List<PecasDomain> pecasLs = new List<PecasDomain>();
            con.Open();
            string Query = "SELECT * FROM Pecas ORDER BY IdPeca";
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PecasDomain peca = new PecasDomain
                {
                    IdPeca = Convert.ToInt32(sdr["IdPeca"]),
                    CodigoPeca = sdr["CodigoPeca"].ToString(),
                    Descricao = sdr["Descricao"].ToString(),
                    Peso = Convert.ToInt32(sdr["Peso"]),
                    PrecoCusto = Convert.ToInt32(sdr["PrecoCusto"]),
                    PrecoVenda = Convert.ToInt32(sdr["PrecoVenda"]),
                    IdFornecedor = Convert.ToInt32(sdr["IdFornecedor"]),
                };
                pecasLs.Add(peca);
            }
            return pecasLs;
        }



    }
}
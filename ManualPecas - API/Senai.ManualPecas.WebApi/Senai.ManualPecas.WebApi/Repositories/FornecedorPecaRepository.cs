using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class FornecedorPecaRepository : IFornecedorPecaInterface
    {

        string Connection = "Data Source=.\\SqlExpress; Initial Catalog=T_ManualPecas;User Id=sa;Pwd=132";

        public void CadastrarPecaFornecedor(int idfor, int idPeca, float preco)
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            string Query = "INSERT INTO PecaFornecedor (IdFornecedor, IdPeca, Preco VALUES(@for, @peca, @preco)";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@for", idfor);
            cmd.Parameters.AddWithValue("@peca", idPeca);
            cmd.Parameters.AddWithValue("@preco", preco);

            cmd.ExecuteReader();
        }

        public void DeletarPecaFornecedor(int idPeca, int idfor) 
        {
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            string Query = "DELETE FROM PecaFornecedor WHERE IdFornecedor = @idF AND IdPeca = @idP";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@idF", idfor);
            cmd.Parameters.AddWithValue("@idP", idPeca);

            cmd.ExecuteReader();
        }

    }
}

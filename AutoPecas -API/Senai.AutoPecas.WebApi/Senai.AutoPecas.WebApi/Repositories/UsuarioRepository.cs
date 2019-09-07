using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private const string StringCon = "Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_AutoPecas;Integrated Security=SSPI";

        AutoPecasContext ctx = new AutoPecasContext();

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            Usuarios userReturn = ctx.Usuarios.FirstOrDefault(user => user.Email == login.Email && user.Senha == user.Senha);
            return userReturn;
        }

        public List<Usuarios> ListarDados()
        {
            //var user = ctx.Usuarios.Include(X => X.Fornecedores.Pecas).ToList();
         
            List<Usuarios> usersLs = new List<Usuarios>();

            string Query = "SELECT Usuarios.IdUsuario, Usuarios.Email, Fornecedores.IdFornecedor, Fornecedores.CNPJ AS Cpnj , Fornecedores.RazaoSocial, Fornecedores.NomeFantasia, Fornecedores.Endereco  FROM Usuarios JOIN Fornecedores ON Usuarios.IdUsuario = Fornecedores.IdUsuario";
            SqlConnection con = new SqlConnection(StringCon);
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read()){
                Usuarios user = new Usuarios{
                    IdUsuario = Convert.ToInt32(sdr["IdUsuario"]),
                    Email = sdr["Email"].ToString(),
                    Fornecedores = new Fornecedores{
                        IdFornecedor = Convert.ToInt32(sdr["IdFornecedor"]),
                        Cnpj = sdr["Cpnj"].ToString(),
                        RazaoSocial  = sdr["RazaoSocial"].ToString(),
                        NomeFantasia = sdr["NomeFantasia"].ToString(),
                        Endereco = sdr["Endereco"].ToString(),
                    }
                };
                usersLs.Add(user);
            }
            return usersLs;
        }
    }
}

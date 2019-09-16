using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;
using Senai.ManualPecas.WebApi.ViewModels;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //instanciar interface
        IFornecedorInterface fornecedorInterface { get; set; }
        //criar controllador
        public LoginController()
        {
            fornecedorInterface = new FornecedorRepository();
        }

        [HttpPost]
        public IActionResult Logar (LoginViewModel logon)
        {
            try
            {
                Fornecedores fornecedorReturn = fornecedorInterface.Buscar(logon);
                if (fornecedorReturn == null)
                {
                    return NotFound(new { mensagem = "Fornecedor inexistente no nosso banco de dados, por favor tente novamente ou cadastre-se na nossa plataforma :)" });
                }

                var claims = new[] 
                {
                    new Claim("CNPJ", fornecedorReturn.Cnpj),
                    new Claim(JwtRegisteredClaimNames.Jti, fornecedorReturn.IdFornecedor.ToString() )
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autenticacao-manual-pecas"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "ManualPecas.WebApi",
                    audience: "ManualPecas.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch(Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }







    }
}
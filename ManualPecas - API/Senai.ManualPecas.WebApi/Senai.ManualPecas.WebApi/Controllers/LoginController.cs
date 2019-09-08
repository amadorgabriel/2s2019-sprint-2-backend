using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;
using Senai.ManualPecas.WebApi.ViewModels;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        //interface
        IUsuarioInterface usuarioInterface { get; set; }

        public LoginController()
        {
            //repository
            usuarioInterface = new UsuarioRepository();
        }

        //login
        [HttpPost]
        public IActionResult Logar(LoginViewModel logon)
        {
            try
            {
                var user = usuarioInterface.BuscarPorEmailSenha(logon);
                if (user == null)
                {
                    return NotFound();
                }

                //gerar clains, chaves, token
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, user.IdUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave_aqui_e_agora_nesse_instante"));

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
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro sucedido" + exe.Message});
            }

        }


    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;
using Senai.Optus.WebApi.ViewModels;


namespace Senai.Optus.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        UsuariosRepository usuariosRepository = new UsuariosRepository();

        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios userRec = usuariosRepository.BuscarPorEmail(login);
                if (userRec == null)
                {
                    return NotFound(new { mensagem = "Email ou Senha Errada(o)" });
                }

                var claims = new[] // sobre o user
               {
                    // chave 
                    new Claim("eu", "nao"),
                    new Claim("sei", "como"),
                    new Claim("mas", "me"),
                    new Claim("ajuda", "por"),
                    new Claim("favor", ":<"),

                    // email
                    new Claim(JwtRegisteredClaimNames.Email, userRec.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, userRec.IdUsuario.ToString()),
                    // permissao
                    new Claim(ClaimTypes.Role, userRec.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aqui-fica-a-chave-autenticacao-para-o-token"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Optus.WebApi",
                    audience: "Optus.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(
                    new{
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Logar >:" + exe.Message });
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        UsuarioRepository usuarioRepositoy = new UsuarioRepository();

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            //Busca por Email
            //se nulo = notFound()
            //else token

            try
            {
                Usuarios UserReturn = usuarioRepositoy.BuscarPorEmailSenha(login);
                if (login == null || UserReturn == null)
                {
                    return NotFound(new { mensagem = "Erro ao Logar, Usuario não encontrado" });
                }

                //gerei declarações do meu token, meio que customizei ele
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Email, UserReturn.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UserReturn.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, UserReturn.Permissao),
                };

                //criei uma chave de seguramça e a configurei
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave_aqui_e_agora_nesse_instante"));

                // fiz alguma parada que não entendi
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // na real, aqui eu realmente crei meu token e configurei ele
                var token = new JwtSecurityToken(
                    issuer: "Inlock.WebApi",
                    audience: "Inlock.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                //pois então me dispus a configurá-lo
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Logar" + exe.Message });
            }

        }
    }
}
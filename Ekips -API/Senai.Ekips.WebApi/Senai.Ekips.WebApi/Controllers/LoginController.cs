using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using Senai.Ekips.WebApi.ViewModels;

namespace Senai.Ekips.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();

        [HttpPost]
        public IActionResult Logar(LoginViewModel log)
        {
            try
            {
                //busquei por email
                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(log);
                if (usuarioBuscado == null)
                {
                    return NotFound();
                }


                //gerei declarações do meu token, meio que customizei ele
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                };

                //criei uma chave de seguramça e a configurei
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave_aqui_e_agora_nesse_instante"));

                // fiz alguma parada que não entendi
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // na real, aqui eu realmente crei meu token e configurei ele
                var token = new JwtSecurityToken(
                    issuer: "Ekips.WebApi",
                    audience: "Ekips.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                //pois então me dispus a configurá-lo
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Logar." + ex.Message });
            }

        }
    }
}
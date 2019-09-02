using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        LoginController loginController = new LoginController();


        [Authorize(Roles = "ADMINISTRADOR , COMUM")]
        [HttpGet]
        public IActionResult Listar()
        {
            int idUser = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            string userPerm = HttpContext.User.Claims.First(user => user.Type == ClaimTypes.Role).Value;
            if (userPerm == "ADMINISTRADOR")
            {
                return Ok(funcionarioRepository.Listar());
            }
            else
            {
                return Ok(funcionarioRepository.BuscarPorId(idUser));
            }
            //como acessar dados da minha requesição

        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios func)
        {
            if (func == null)
            {
                return NotFound(new { mensagem = "Erro ao Cadastrar Funcionário >:" });
            }

            if (func.IdCargo == null || func.IdSetor == null)
            {
                return NotFound(new { mensagem = "Erro ao Cadastrar Funcionário, Usuario ou Cargos Inexistentes  >:" });
            }

            if (func.IdCargoNavigation.Ativo == false)
            {
                return NotFound(new { mensagem = "Erro ao Cadastrar Funcionário, Cargo Inativo >:" });
            }

            funcionarioRepository.Cadastrar(func);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionarios func)
        {
            try
            {
                funcionarioRepository.Atualizar(id, func);
                if (func == null)
                {
                    return NotFound();
                }
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar >:" + exe.Message });
            }

            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                funcionarioRepository.Deletar(id);
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Deletar >:" + exe.Message });
            }

            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("dados")]
        public IActionResult ListarDadosFunc()
        {
            int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            string UsuarioPermissao = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
            return Ok(new { UsuarioId = UsuarioId, Permissao = UsuarioPermissao });
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{valor}/salarios")]
        public IActionResult BuscarPorSalarioIgualOuMaior(int valor)
        {
            var listaFunc = funcionarioRepository.BuscarPorSalarioIgualOuMaior(valor);
            return Ok(listaFunc);
        }

        // coluna é a tabela
        //ordem é DESC ou ASC
        // [HttpGet("{coluna}/{ordem}")]
        // public IActionResult BuscarEntidadePorOrdem(string coluna, string ordem)
        // {

        //     if (coluna == "f")
        //     {
        //         //um método
        //         return Ok(funcionarioRepository.BuscarEntidadeFuncionario(ordem));
        //     }
        //     else
        //     {
        //         return NotFound(new { mensagem = "Coluna não identificada, por favor reescreva" });
        //     }
        // }




    }
}
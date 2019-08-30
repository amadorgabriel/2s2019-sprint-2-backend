using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles = "ADMINISTRADOR"), Authorize(Roles="COMUM")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepository.Listar());
        }

       

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios func)
        {
            if (func == null)
            {
                return NotFound(new { mensagem = "Erro ao Cadastrar >:" });
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



    }
}
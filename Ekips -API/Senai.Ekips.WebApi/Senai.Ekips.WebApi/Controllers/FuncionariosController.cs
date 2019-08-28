using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepository.Listar());
        }

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
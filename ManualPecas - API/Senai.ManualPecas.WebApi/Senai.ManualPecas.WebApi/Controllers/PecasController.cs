using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        public IPecaInterface pecaInterface {get; set;}

        public PecasController()
        {
            pecaInterface = new PecaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = pecaInterface.ListarTodas();
            if(lista == null)
            {
                return NotFound(new { mensagem = "Lista nula" });
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Cadastrar (Pecas peca)
        {
            try
            {
                if (peca == null)
                {
                    return BadRequest(new { mensagem = "Peca com itens pendentes, por favor, revise" });
                }
                pecaInterface.Cadastrar(peca);
                return Ok();
            }
            catch(Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pecas peca)
        {
            try
            {
                if (peca == null)
                {
                    return BadRequest(new { mensagem = "Peca com itens pendentes, por favor, revise" });
                }
                pecaInterface.Atualizar(id, peca);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            pecaInterface.Deletar(id);
            return Ok();
        }
    }
}
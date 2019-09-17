using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        public JogoRepository jogosRepository = new JogoRepository();


        //GET - listar
        //POST -cadastrar
        //DELETE - deletar
        //PUT -atualizar

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogosRepository.ListarJogos());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos game)
        {
            if (game == null)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar >: Algo está errado ou ausente, por faor corrija" });
            }
            jogosRepository.Cadastrar(game);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int Id, Jogos game)
        {
            if (game == null)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar >: Algo está errado ou ausente, por faor corrija" });
            }
            jogosRepository.Atualizar(Id, game);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogosRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{nome}/buscar")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(jogosRepository.BuscarPorNome(nome));
        }

        [Authorize]
        [HttpGet("visualizar")]
        public IActionResult VisualizarTudo()
        {
            return Ok(jogosRepository.VisualizarTudo());
        }

        [Authorize]
        [HttpGet("buscarmaiscaros")]
        public IActionResult BuscarMaisCaros()
        {
            List<Jogos> jogosLs = jogosRepository.BuscarMaisCaros();
            if (jogosLs == null)
            {
                return NotFound(new { mensagem = "Opa, Não Temos mais Games Cadastrados" });
            }
            return Ok(jogosLs);
        }

        [Authorize]
        [HttpGet("buscarrecentes")]
        public IActionResult BuscarMaisRecentes()
        {
            List<Jogos> jogosLs = jogosRepository.BuscarMaisRecentes();
            if(jogosLs == null)
            {
                return NotFound(new { mensagem = "Opa, Não Temos mais Games Cadastrados" });
            }
            return Ok(jogosLs);
        }


    }
}
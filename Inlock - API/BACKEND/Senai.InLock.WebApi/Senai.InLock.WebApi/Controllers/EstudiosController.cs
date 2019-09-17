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
    
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();

        [Authorize (Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstudioRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar" + ex.Message });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            EstudioRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                Estudios EstudioBuscado = EstudioRepository.BuscarPorId(estudio.EstudioId);
                if (EstudioBuscado == null)
                    return NotFound();
                EstudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar" + ex.Message });
            }
        }

        [HttpGet("{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Estudios estudios = EstudioRepository.BuscarPorNome(nome);
            if (estudios == null)
                return NotFound();
            return Ok(estudios);
        }

        [HttpGet("pais/{pais}")]
        public IActionResult BuscarPorPais(string pais)
        {
            var estudios = EstudioRepository.BuscarPorPais(pais);
            if (estudios == null)
                return NotFound();
            return Ok(estudios);
        }
    }
}
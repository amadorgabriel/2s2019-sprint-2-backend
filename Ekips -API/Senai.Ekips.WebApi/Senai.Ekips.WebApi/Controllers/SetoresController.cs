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
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SetoresController : ControllerBase
    {
        SetoresRepository setoresRepository = new SetoresRepository();

        [Authorize] // estar logado
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(setoresRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(setoresRepository.BuscarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Setores setor)
        {
            if (setor == null)
            {
                return NotFound(new { mensagem = "Erro ao Cadastrar >:" });
            }

            setoresRepository.Cadastrar(setor);
            return Ok();
        }

    }
}
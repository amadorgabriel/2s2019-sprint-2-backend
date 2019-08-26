using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        EventoRepository eventoRepository = new EventoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
             return Ok(eventoRepository.Listar());      
        }

        [HttpPost]
        public IActionResult Cadastrar(Eventos evento)
        {
            try
            {
                eventoRepository.Cadastrar(evento);
                return Ok();
            }catch(Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar" + exe.Message });
            }

        }
    }
}
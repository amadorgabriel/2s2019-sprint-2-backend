using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistasRepository artistasRepository = new ArtistasRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return Ok(artistasRepository.Listar());
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                artistasRepository.Cadastrar(artista);
                if (artista == null)
                {
                    return NotFound();
                }
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro ao Cadastrar:" + exe.Message });
            }
            return Ok();
        }



    }
}
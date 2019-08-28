using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
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

<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
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
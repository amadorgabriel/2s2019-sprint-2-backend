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
    public class EstilosController : ControllerBase
    {
        EstilosRepository estilosRepository = new EstilosRepository();

        // Estilos - GET, POST, PUT, DELETE

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estilosRepository.Listar());
        }

        [Authorize (Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estilosRepository.Cadastrar(estilo);
                if (estilo == null)
                {
                    return NotFound();
                }

            }
            catch (Exception exe)
<<<<<<< HEAD
            {
                return BadRequest(new { mensagem = "Erro:" + exe.Message });
            }
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                estilosRepository.Atualizar(estilo);
                if (estilo == null)
                {
                    return NotFound();
                }
            }
            catch (Exception exe)
=======
>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
            {
                return BadRequest(new { mensagem = "Erro:" + exe.Message });
            }
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
<<<<<<< HEAD
=======
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                estilosRepository.Atualizar(estilo);
                if (estilo == null)
                {
                    return NotFound();
                }
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro:" + exe.Message });
            }
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            estilosRepository.Deletar(id);
            return Ok();
        }

<<<<<<< HEAD
        [Authorize]
        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {
=======
        // [Authorize]
        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {

>>>>>>> 264beac5f35dfad7b79e3808f1070681e6854605
            Estilos estiloRetornado = estilosRepository.BuscarPorId(id);
            return Ok (estiloRetornado);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    // RESULTADO:
    // GET - BuncandoPorId e ListandoTodos



    [Produces("application/json")]
    [Route("api/[controller]")] // - URL: api/Estilos --
    [ApiController]
    public class EstilosController : ControllerBase // - ControllerBase é um resumo do Controller
    {

     

        EstiloRepository EstiloRepository = new EstiloRepository();
        [HttpGet]
        public IEnumerable<EstiloDomain> ListarTodos()
        {
            return EstiloRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok(estilos);
        }


        // o controller devera receber o id que eu quero buscar
        // GET /api/estilos/3
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain estiloDomain = EstiloRepository.BuscarPorId(id);
            if (estiloDomain == null)
                return NotFound();
            return Ok(estiloDomain);
        }

        [HttpDelete("{id}")] // -- Http DELETE, apenas isso
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }

        [HttpPut] // -- Http DELETE, apenas isso
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Atualizar(estiloDomain);
            return Ok();
        }

    }
}
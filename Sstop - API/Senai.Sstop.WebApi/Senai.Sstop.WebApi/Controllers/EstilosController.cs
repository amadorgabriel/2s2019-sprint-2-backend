using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repository;

namespace Senai.Sstop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")] // - URL: api/Estilos --
    [ApiController]
    public class EstilosController : ControllerBase // - ControllerBase é um resumo do Controller
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
            {
                new EstiloDomain { IdEstilo = 1, Nome = "Rock" },
                new EstiloDomain { IdEstilo = 2, Nome = "Rap" },
                new EstiloDomain { IdEstilo = 3, Nome = "MPB" }

            };

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo); // Retorna o Estilo, não uma mensagem "OK" :)
        }



        EstiloRepository EstiloRepository = new EstiloRepository();
        [HttpGet]
        public IEnumerable<EstiloDomain> ListarTodos()
        {
            return EstiloRepository.Listar();
        }

        


        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            estilos.Add(
                new EstiloDomain
                {
                    IdEstilo = estilos.Count + 1,
                    Nome = estiloDomain.Nome
                }
            );
            return Ok(estilos);
        }
    }
}
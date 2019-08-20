using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repository;

namespace Senai.Filmes.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();
        List<GeneroDomain> generos = new List<GeneroDomain>()
        {
            new GeneroDomain {IdGenero = 1, Nome = "Ação"},
            new GeneroDomain {IdGenero = 2, Nome = "Terror"},
            new GeneroDomain {IdGenero = 3, Nome = "Romance"}
        };

        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos() // Lista todos Jasons de uma lista
        {
            return generoRepository.Listar();
        }

        [HttpGet("{id}")] // Lista um só objeto da lista
        public IActionResult BuscarPorId(int id)
        {
            GeneroDomain Genero = generos.Find(x => x.IdGenero == id); /// lambda == estrutura repetição simplificada
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero); 
        }

        [HttpPost] // Poderia passar pela url mas JSON é mais seguro
        public IActionResult CadastrarGenero (GeneroDomain generoDomain)
        {
            generos.Add(
                new GeneroDomain
                {
                    IdGenero = generos.Count + 1,
                    Nome = generoDomain.Nome
                }
            );
            return Ok(generos);
        }

    }
}
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
    public class FilmesController : ControllerBase
    {
        FilmeRepository filmeRepository = new FilmeRepository();
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public List<FilmeDomain> ListarTodos()
        {
            var lista = filmeRepository.Listar();
            if (lista == null)
            {
                NotFound();
            }
            return lista;
        }

        [HttpGet("{id}")]
        public FilmeDomain BuscarPorId(int id)
        {
            var filme = filmeRepository.BuscarPorId(id);
            if (filme == null)
            {
                NotFound();
            }
            return filme;
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            filmeRepository.Cadastar(filme);
            return Ok();
        }

        [HttpGet("{id}/filmes")]
        public List<FilmeDomain> BuscarFilmePorIdGenero(int id)
        {
            var genero = generoRepository.BuscarPorId(id);

            var filmeLS = filmeRepository.BuscarFilmesPorIdGenero(id);
            if (filmeLS == null)
            {
                NoContent(); // Não existe o Filme
            }

            if (genero == null)
            {
                NotFound(); //Não existe o genero
            }

            return filmeLS;
        }

        //- Dado uma determinada palavra do filme, trazer a lista de registros encontrados.
        //GET /api/filmes/{ nome}/buscar

        [HttpGet("{nome}/buscar")]
        public List<FilmeDomain> BuscarFilmesPorPalavras(string busca)
        {

        }
    }
}
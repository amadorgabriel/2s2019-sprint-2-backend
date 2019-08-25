using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repository;

namespace Senai.BookStore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        AutoresRepository autoresRepository = new AutoresRepository();


        [HttpGet]
        public List<AutoresDomain> ListarTodos(){
            var autoresLs = autoresRepository.ListarTodos();
            if ( autoresLs == null )
            {
                NotFound();
            }
            return autoresLs;
        }

        [HttpPost]
        public IActionResult Cadastrar (AutoresDomain autor){
            autoresRepository.Cadastrar(autor);
            return Ok();
        }

        [HttpGet("{id}/livros")]
        public List<LivrosDomain> BuscarPorIdAutor(int id){
            var livrosLs = autoresRepository.BuscarLivroPorIdAutor(id);
            if (livrosLs == null)
            {
                NotFound();
            }
            return livrosLs;
        }

    }
}
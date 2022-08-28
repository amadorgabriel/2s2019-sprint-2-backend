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
    public class GenerosController : ControllerBase
    {
        GenerosRepository generosRepository = new GenerosRepository();
        public List<GenerosDomain> ListarTodos()
        {
            var generosLs = generosRepository.ListarTodos();
            if (generosLs == null)
            {
                NotFound();
            }
            return generosLs;
        }

        [HttpPost]
        public IActionResult Cadastrar(GenerosDomain genero){
            generosRepository.Cadastrar(genero);
            return Ok();
        }

        // [HttpGet("buscar/{nome}/livros")]
        // public List<LivrosDomain> BuscarLivrosPorNomeGenero(string nome){
        //     var livrosLs = generosRepository.BuscarLivrosPorNomeGenero(nome);
        //     Console.WriteLine(nome);
        //     if (livrosLs == null)
        //     {
        //         NotFound();
        //     }
        //     return livrosLs;
        // }

    }
}
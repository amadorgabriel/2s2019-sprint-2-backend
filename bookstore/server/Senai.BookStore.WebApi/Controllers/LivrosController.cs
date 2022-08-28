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
    public class LivrosController : ControllerBase
    {
        LivrosRepository livrosRepository = new LivrosRepository();

        [HttpGet]
        public List<LivrosDomain> ListarTodos(){
            var livrosLs = livrosRepository.ListarTodos();
            if (livrosLs == null )
            {
                NotFound(); //404
            }
            return livrosLs;
        }

        [HttpPost]
        public IActionResult Cadastrar(LivrosDomain livro){
           livrosRepository.Cadastrar(livro);
           return Ok(); 
        }

        [HttpGet("{id}")]
        public LivrosDomain BuscarPorId(int id){
            var livro = livrosRepository.BuscarPorId(id);
            if (livro == null)
            {
                NotFound();
            }
            return livro;
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, LivrosDomain livro){
            livrosRepository.Atualizar(id, livro);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar (int id){
            livrosRepository.Deletar(id);
            return Ok();
        }

       
    }
}
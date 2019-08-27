using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Produces("application/json") ]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriasRepository categoriasRepository = new CategoriasRepository();
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(categoriasRepository.Listar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar (Categorias categoria)
        {
            try
            {
                categoriasRepository.Cadastrar(categoria);
                return Ok();
            }catch(Exception exe)
            {
                return BadRequest(new { mensagem = "Opa, erro:" + exe.Message });
            }
        }

        [Autorhize (Roles = "ADMINISTRADOR") ]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int Id)
        {
            Categorias categoria = categoriasRepository.BuscarPorId(Id);
            if(categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int Id)
        {
            categoriasRepository.Deletar(Id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                //pesquisando a categoria
                Categorias categoriaRetornada = categoriasRepository.BuscarPorId(categoria.IdCategoria);
                if(categoriaRetornada == null)
                {
                    return NotFound();
                }
                categoriasRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new {mensagem = "HASHUAHSUHSUHSUHAS, se deu mau aí..." });
            }
        }


    }
}
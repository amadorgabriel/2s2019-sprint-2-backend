using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        public IFornecedorInterface fornecedorInterface { get; set; }

        public FornecedorController()
        {
            fornecedorInterface = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = fornecedorInterface.ListarFornecedores();

            if (lista == null)
            {
                return NotFound(new { mensagem = "Lista nula" });
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult CadastrarFornecedor(Fornecedores f)
        {
            try
            {
                if (f == null)
                {
                    return BadRequest(new { mensagem = "Peca com itens pendentes, por favor, revise" });
                }
                fornecedorInterface.CadastrarFornecedor(f);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }

      

    }
}
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
    public class FornecedoresController : ControllerBase
    { 

        //interface
        IFornecedorInterface fornecedorInterface { get; set; }

        public FornecedoresController()
        {
            //repositorio
            fornecedorInterface = new FornecedorRepository();
        }


        [HttpPost]
        public IActionResult Cadastrar(Fornecedores forn)
        {
            try
            {
                fornecedorInterface.Cadastrar(forn);
                if (forn == null)
                {
                    return NotFound(new { mensagem = "Algo deu errado, por favor tente novamente" });
                }
                return Ok();

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Algo deu errado >:" + exe.Message });
            }
        }
    }
}
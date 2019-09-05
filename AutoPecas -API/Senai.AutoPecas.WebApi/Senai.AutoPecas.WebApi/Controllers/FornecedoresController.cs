using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        IFornecedorRepository fornecedorInterface {get; set;}
        public FornecedoresController(){
            fornecedorInterface = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult ListarDados(){
            return Ok(fornecedorInterface.ListarDados());
        }

    }
}
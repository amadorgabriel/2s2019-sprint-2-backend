using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Produces ("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorPecasController : ControllerBase
    {
        IFornecedorPecaInterface fornecedorPecaInterface { get; set; }
        public FornecedorPecasController()
        {
            fornecedorPecaInterface = new FornecedorPecaRepository();
        }
        
        //CADASTRAR
        [Authorize]
        [HttpPost]
        public IActionResult CadastrarPecaFornecedor(int idPeca, float preco)
        {

        }

        //DELETAR
        [Authorize]
        [HttpDelete]
        public IActionResult DeletarPecaFornecedor(int idPeca, int idfor)
        {

        }

    }
}
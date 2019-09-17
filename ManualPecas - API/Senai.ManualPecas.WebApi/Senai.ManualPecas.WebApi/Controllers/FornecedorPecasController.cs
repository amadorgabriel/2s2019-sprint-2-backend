using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorPecasController : ControllerBase
    {
        IFornecedorPecaInterface fornecedorPecaInterface { get; set; }
        IFornecedorInterface fornecedorInterface { get; set; }

        public FornecedorPecasController()
        {
            fornecedorPecaInterface = new FornecedorPecaRepository();
            fornecedorInterface = new FornecedorRepository();
        }
        
        //CADASTRAR
        [Authorize]
        [HttpPost]
        public IActionResult CadastrarPecaFornecedor(FornecedorPeca pecaF)
        {
            int idfor = Convert.ToInt32(HttpContext.User.Claims.First(i => i.Type == JwtRegisteredClaimNames.Jti).Value);
            try
            {
                if (pecaF.IdPeca == null || pecaF.Preco == null)
                {
                    return BadRequest(new { mensagem = "Algo deu errado" });
                }

                pecaF.IdFornecedor = idfor;

                fornecedorPecaInterface.CadastrarPecaFornecedor(pecaF);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }

        //DELETAR
        [Authorize]
        [HttpDelete ("deletar/{idPeca}")]
        public IActionResult DeletarPecaFornecedor(int idPeca)
        {
            int idForn = Convert.ToInt32(HttpContext.User.Claims.First(i => i.Type == JwtRegisteredClaimNames.Jti).Value);
            var forn = fornecedorInterface.BuscarPorId(idForn);

            try
            {
                fornecedorPecaInterface.DeletarPecaFornecedor(idPeca, idForn);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro >:" + exe.Message });
            }
        }

        [HttpGet("fornecedorbarato/{idPeca}")]
        public IActionResult TrazerFornecedorBarato(int idPeca)
        {

        }

    }
}
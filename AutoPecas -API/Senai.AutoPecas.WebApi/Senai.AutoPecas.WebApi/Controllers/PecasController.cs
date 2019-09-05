using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {

        private IPecasRepository PecasInterface { get; set; }
        private IFornecedorRepository FornecedorInterface { get; set; }


        public PecasController()
        {
            PecasInterface = new PecaRepository();
            FornecedorInterface = new FornecedorRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            //pegar o dado do token [IdUsuario]
            int IdUser = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            //pelo IdUsuario descobrir o Fornecedor
            Fornecedores fornecedor = FornecedorInterface.BuscarPorIdUsuario(IdUser);
            //listar pecas quando Idfornecedor for igual
            return Ok(PecasInterface.Listar(fornecedor));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorid(int id)
        {
            return Ok(PecasInterface.BuscarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Casdastrar(Pecas peca)
        {
            try
            {
                PecasInterface.Cadastrar(peca);
                return Ok();

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Algum dado incorreto" + exe.Message });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pecas peca)
        {
            int IdUser = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            Fornecedores fornecedor = FornecedorInterface.BuscarPorIdUsuario(IdUser);

            try
            {
                if (peca == null)
                {
                    return BadRequest(new { mensagem = "Informações Pendentes pararealizar o UPDATE" });
                }

                if (peca.IdFornecedor != fornecedor.IdUsuario)
                {
                    return NotFound();
                }

                PecasInterface.Atualizar(id, peca);
                return Ok();
            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Algum dado incorreto ou nulo" + exe.Message });
            }
            
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                PecasInterface.Deletar(id);
                return Ok();

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Peça Inexistente" + exe.Message });
            }
        }

      
    }
}
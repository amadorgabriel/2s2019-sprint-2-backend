using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class PecasController : ControllerBase
    {

        public IPecasInterface pecasInterface { get; set; }
        public IFornecedorInterface fornecedorInterface { get; set; }


        public PecasController()
        {
            pecasInterface = new PecaRepository();
            fornecedorInterface = new FornecedorRepository();
        }

        //LISTAR
        [HttpGet]
        public IActionResult Listar()
        {
            if (pecasInterface.ListarTodas() == null)
            {
                return NotFound(new { mensagem = "Lista nula" });
            }
            return Ok(pecasInterface.ListarTodas());
        }

        //CADASTRAR
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            //verificar qual fornecedor onde só cadastrará para si mesmo
            //int idUser = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

            //Fornecedores forn = fornecedorInterface.TrazerFornecedorPorIdUser(idUser);
            //if (forn == null)
            //{
            //   return BadRequest(new { mensagem = "O Usuário não possui um fornecedor :(" });
            //}

            try
            {
                pecasInterface.Cadastrar(peca);
                if (peca == null)
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

        //ATUALIZAR
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pecas peca)
        {
            //verificar qual fornecedor onde só atualizará suas pecas
            try
            {
                pecasInterface.Atualizar(id, peca);
                if (peca == null)
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


        //DELETAR
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            //verificar qual fornecedor onde só deletará sua peca
            pecasInterface.Deletar(id);
            return Ok();
        }




    }
}
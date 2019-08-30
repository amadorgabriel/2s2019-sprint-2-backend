﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class CargosController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id){
            return Ok( cargoRepository.BuscarPorId(id) );
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo){
            try
            {
                cargoRepository.Cadastrar(cargo);
                if (cargo == null)
                {
                    NotFound(new {mensagem = "Cargo não definido corretamente :(" });
                }
            }
            catch (System.Exception exe)
            {
                
                BadRequest( new {mensagem = "Erro ao Cadastrar >:" + exe.Message} );
            }
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cargos cargo){
             try
            {
                cargoRepository.Atualizar(id, cargo);
                if (cargo == null)
                {
                    NotFound(new {mensagem = "Cargo não definido corretamente :(" });
                }
            }
            catch (System.Exception exe)
            {
                
                BadRequest( new {mensagem = "Erro ao Atualizar >:" + exe.Message} );
            }
            return Ok();
        }


    }
}
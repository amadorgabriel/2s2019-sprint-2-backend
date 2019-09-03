using System;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class PecasController : ControllerBase
    {
        public PecaRepository pecaRepository = new PecaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            var listaPecas = pecaRepository.Listar();
            return Ok(listaPecas);
        }


    }
}
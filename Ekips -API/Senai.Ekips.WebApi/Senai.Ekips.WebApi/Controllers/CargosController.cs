using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class CargosController : ControllerBase
    {
        CargoRepository cargoRepository = new CargoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepository.Listar());
        }


    }
}
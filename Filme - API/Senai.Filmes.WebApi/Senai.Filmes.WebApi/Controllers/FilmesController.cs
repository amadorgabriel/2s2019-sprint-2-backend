using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;

namespace Senai.Filmes.WebApi.Controllers
{
    [Produces("application/json") ]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        [HttpGet]
        public List<FilmeDomain> ListarTodos()
        {

        }
    }
}
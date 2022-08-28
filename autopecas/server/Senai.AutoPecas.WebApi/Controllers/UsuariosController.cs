using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuariosRepository usuarioInterface {get; set;}
        public UsuariosController(){
            usuarioInterface = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarDados(){
            return Ok(usuarioInterface.ListarDados());
        }

    }
}
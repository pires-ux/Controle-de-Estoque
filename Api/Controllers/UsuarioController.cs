using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("cadastro")]
        public async Task<IActionResult> CriarConta(Usuario usuario)
        {
            return Ok(usuario);
        }
    }
}

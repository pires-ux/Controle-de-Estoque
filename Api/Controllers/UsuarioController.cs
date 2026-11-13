using Api.DTOs;
using Api.Models;
using Api.Repositorys.Interface;
using Api.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuarioController> _log;

        public UsuarioController(IUsuarioService service, ILogger<UsuarioController> log)
        {
            _service = service;
            _log = log;
        }


        [HttpPost("cadastro")]
        public async Task<IActionResult> CriarConta([FromBody] CriarUsuarioDTO criar)
        {
            var response = await _service.CriarUsuario(criar);
            if(response == null)
            {
                _log.LogWarning("Erro ao criar usuário");
                return BadRequest("Erro ao criar usuário");
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogarConta([FromBody] LoginDTO login)
        {
            var resut = await _service.LogarUsuario(login);
            if (resut == null) return BadRequest("Email ou senha incorreta");

            return Ok(resut);
        }
    }
}

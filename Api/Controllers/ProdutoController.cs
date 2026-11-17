using Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        [HttpPost("AddProduto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] AdicionarProdutoDTO adicionar)
        {


            return null;
        }

        [HttpPut("EditarProduto")]
        public async Task<IActionResult> Editar([FromBody] EditProdutoDTO edit)
        {

            return null;
        }

        [HttpGet("Mostrar")]
        public async Task<IActionResult> Mostrar()
        {

            return null;
        }

        [HttpDelete("Excluir/ {id}")]
        public async Task<IActionResult> Excluir(int id)
        {

            return null;
        }


    }
}

using Api.DTOs.Produto;
using Api.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _serv;
        private readonly ILogger<ProdutoController> _log;
        public ProdutoController(IProdutoService serv, ILogger<ProdutoController> log)
        {
            _serv = serv;
            _log = log;
        }


        [HttpPost("AddProduto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] AdicionarProdutoDTO adicionar)
        {
            var adicionou = await _serv.Adicionar(adicionar);
            if (!adicionou) return BadRequest("erro ao adicionar produto");
            return Ok("Produto adicionado");
        }

        [HttpPut("EditarProduto/{id}")]
        public async Task<IActionResult> Editar(int id,[FromBody] EditProdutoDTO edit)
        {
            var produto = await _serv.Editar(edit, id);
            if (produto == null) return BadRequest("Não ouve mudança no produto");

            return Ok($"Mudança de produto feita");
        }

        [HttpGet("Mostrar")]
        public async Task<IActionResult> Mostrar()
        {
            var produtos = await _serv.Mostrar();
            if(produtos == null)return BadRequest("Nenhum produto encontrado");

            return Ok(produtos);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            if (!await _serv.Excluir(id)) {
                BadRequest("produto não encontrado"); 
            }
            return Ok("Produto excluido");
        }


    }
}

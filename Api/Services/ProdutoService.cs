using Api.DTOs;
using Api.Models;
using Api.Repositorys.Interface;
using Api.Services.Interface;

namespace Api.Services
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository _repo;
        private readonly ILogger<ProdutoService> _log;

        public ProdutoService(IProdutoRepository repo, ILogger<ProdutoService> log)
        {
            _log = log;
            _repo = repo;
        }


        public async Task<bool> Adicionar(AdicionarProdutoDTO adicionar)
        {

            return false;
        }

        public Task<Produto> Editar(EditProdutoDTO edit)
        {
            return null;
        }


        public Task<bool> Excluir(int id)
        {
            return null;
        }


        public Task<List<Produto>> Mostrar()
        {
            return null;
        }
    }
}

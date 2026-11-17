using Api.Data;
using Api.DTOs;
using Api.Models;
using Api.Repositorys.Interface;

namespace Api.Repositorys
{
    public class RepositoryProduto: IProdutoRepository
    {
        private readonly Banco _db;
        private readonly ILogger<RepositoryProduto> _log;

        public RepositoryProduto(Banco db, ILogger<RepositoryProduto> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<Produto> Adicionar(AdicionarProdutoDTO adicionar)
        {
            return null;
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

using Api.Data;
using Api.DTOs;
using Api.Models;
using Api.Repositorys.Interface;
using Microsoft.Identity.Client.NativeInterop;

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

        public async Task<bool> Adicionar(Produto adicionar)
        {
            try
            {
                _db.Produtos.Add(adicionar);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("erro ao adicionar produto");
            }
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

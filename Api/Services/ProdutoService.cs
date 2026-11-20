using Api.DTOs.Produto;
using Api.Models;
using Api.Repositorys.Interface;
using Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

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


        public async Task<bool> Adicionar( AdicionarProdutoDTO adicionar)
        {
            var produto = new Produto
            {
                Descricao = adicionar.Descricao,
                Preco = adicionar.Preco,
                ProdutoNome = adicionar.NomeProduto,
                TotalValor = adicionar.TotalValor,
                Quantidade = adicionar.Estoque
            };
            bool adicionou = await  _repo.Adicionar(produto);
            if (!adicionou) return false;

            return true;
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
            var produtos = _repo.Mostrar();
            if (produtos == null) return null!;

            return produtos;
        }
    }
}

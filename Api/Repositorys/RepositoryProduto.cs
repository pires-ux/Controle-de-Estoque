using Api.Data;
using Api.DTOs.Produto;
using Api.Models;
using Api.Repositorys.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Produto> Editar(EditProdutoDTO edit, int id)
        {
            var editarProduto = _db.Produtos.Find(id);

            if(editarProduto == null)
            {
                return null;
            }

            editarProduto!.Descricao = edit.Descricao;
            editarProduto.Preco = edit.Preco;
            editarProduto.Quantidade = edit.Quantidade;
            editarProduto.TotalValor = edit.TotalValor;
            editarProduto.ProdutoNome = edit.NomeProduto;

            _db.SaveChanges();
            
            var produto = _db.Produtos.Find(id);
            _log.LogInformation($"mudança feita {produto}");
            return produto!;
        }


        public async Task<bool> Excluir(int id)
        {
            var produtoDeletar = _db.Produtos.Find(id);
            if(produtoDeletar != null)
            {
                _db.Produtos.Remove(produtoDeletar);
                _db.SaveChanges();
                return true;
            }
            return false;
        }


        public async Task<List<Produto>> Mostrar()
        {
            return _db.Produtos.ToList();
        }
    }
}

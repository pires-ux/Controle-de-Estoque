using Api.DTOs;
using Api.Models;

namespace Api.Repositorys.Interface
{
    public interface IProdutoRepository
    {

        Task<Produto> Adicionar(AdicionarProdutoDTO adicionar);
        Task<Produto> Editar(EditProdutoDTO edit);
        Task<bool> Excluir(int id);
        Task<List<Produto>> Mostrar();

    }
}

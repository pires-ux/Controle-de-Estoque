using Api.DTOs.Produto;
using Api.Models;

namespace Api.Repositorys.Interface
{
    public interface IProdutoRepository
    {

        Task<bool> Adicionar(Produto adicionar);
        Task<Produto> Editar(EditProdutoDTO edit);
        Task<bool> Excluir(int id);
        Task<List<Produto>> Mostrar();

    }
}

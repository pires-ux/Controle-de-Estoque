using Api.DTOs;
using Api.Models;

namespace Api.Services.Interface
{
    public interface IProdutoService
    {

        Task<bool> Adicionar(AdicionarProdutoDTO adicionar);
        Task<Produto> Editar(EditProdutoDTO edit);
        Task<bool> Excluir(int id);
        Task<List<Produto>> Mostrar();

    }
}

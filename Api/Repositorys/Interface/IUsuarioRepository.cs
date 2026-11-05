using Api.DTOs;
using Api.Models;

namespace Api.Repositorys.Interface
{
    public interface IUsuarioRepository
    {

        Task<Usuario> CriarUsuario(CriarUsuarioDTO criar);
        Task<bool> VerificarEmail(string email);
    }
}

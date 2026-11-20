using Api.DTOs.Usuario;

namespace Api.Services.Interface
{
    public interface IUsuarioService
    {

        Task<ResponseUsuarioDTO> CriarUsuario(CriarUsuarioDTO criar);
        Task<ResponseUsuarioDTO> LogarUsuario(LoginDTO login);
    }
}

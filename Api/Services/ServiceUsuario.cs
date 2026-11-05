using Api.DTOs;
using Api.Repositorys.Interface;
using Api.Services.Interface;

namespace Api.Services
{
    public class ServiceUsuario: IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly ILogger<ServiceUsuario> _log;

        public ServiceUsuario(IUsuarioRepository repo, ILogger<ServiceUsuario> log)
        {
            _repo = repo;
            _log = log;
        }

        public async Task<ResponseUsuarioDTO> CriarUsuario(CriarUsuarioDTO criar)
        {
            if(await _repo.VerificarEmail(criar.Email))
            {
                _log.LogWarning("Erro ao criar usuário: Email já cadastrado");
                return null!;
            }

            var usuario = await _repo.CriarUsuario(criar);
            return new ResponseUsuarioDTO
            {
                usuario = usuario,
                token = "Token de autenticação",
            };
        }
    }
}

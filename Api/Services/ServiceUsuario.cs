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
            var token = BCrypt.Net.BCrypt.HashPassword(criar.Senha);
            criar.Senha = token;
            var usuario = await _repo.CriarUsuario(criar);
            return new ResponseUsuarioDTO
            {
                usuario = usuario,
                token = "Token de autenticação",
            };
        }

        public async Task<ResponseUsuarioDTO> LogarUsuario(LoginDTO login)
        {
            var result = await _repo.BuscarEmail(login.Email);
            if (result == null) return null!;

            bool verificarSenha = BCrypt.Net.BCrypt.Verify(result.Senha, login.Senha);
            if (verificarSenha) return new ResponseUsuarioDTO
            {
                usuario = result,
                token = "token"
            };

            else return null!;
        }
    }
}

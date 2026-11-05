using Api.Data;
using Api.DTOs;
using Api.Models;
using Api.Repositorys.Interface;
using Api.Services.Interface;
using Microsoft.EntityFrameworkCore;


namespace Api.Repositorys
{
    public class RepositoryUsuario: IUsuarioRepository
    {
        private readonly Banco _banco;
        private readonly ILogger<RepositoryUsuario> _log;

        public RepositoryUsuario(Banco banco, ILogger<RepositoryUsuario> log)
        {
            _banco = banco;
            _log = log;
        }

        public async Task<Usuario> CriarUsuario(CriarUsuarioDTO criar)
        {
            var criarusuario = new Usuario
            {
                Nome = criar.Nome,
                Email = criar.Email,
                Senha = criar.Senha
            };
            await _banco.Usuarios.AddAsync(criarusuario);
            _banco.SaveChanges();
            var usuario = await _banco.Usuarios.FirstOrDefaultAsync(x => x.Email == criar.Email);

            if (usuario == null)
            {
                _log.LogError("Erro ao criar usuário");
                throw new Exception("Erro ao criar usuário");
            }

            return usuario!;
        }

        public async Task<bool> VerificarEmail(string email)
        {
            var usuario = await _banco.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if (usuario == null)
            {
                return false;
            }
            return true;
        }
    }
}

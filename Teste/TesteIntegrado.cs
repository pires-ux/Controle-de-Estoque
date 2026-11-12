using Api;
using Api.DTOs;
using Microsoft.Identity.Web.TokenCacheProviders;
using System.Text.Json;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Teste
{
    public class TesteIntegrado: IClassFixture<ConfiguracaoDeBanco>
    {
        private readonly HttpClient _client;

        public TesteIntegrado(ConfiguracaoDeBanco factory)
        {
            factory.LimparBanco();
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Cadastro_Sucesso()
        {
            var criar = new CriarUsuarioDTO
            {
                Nome = "teste",
                Email = "teste@gmail.com",
                Senha = "0923242"
            };
            var json = JsonSerializer.Serialize(criar);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync("api/Usuario/cadastro", content);

            
        }

        [Fact]
        public void Login_Sucesso()
        {

        }
    }
}

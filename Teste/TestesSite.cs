
using Microsoft.Playwright;
using Xunit;

namespace Teste
{
    public class TestesSite
    {
        [Fact]
        public async Task DeveAbrirUmaPagina()
        {
            using var playwright = await Playwright.CreateAsync();

            await using var navegador =
                await playwright.Chromium.LaunchAsync(
                    new BrowserTypeLaunchOptions
                    {
                        Headless = true
                    });

            var pagina = await navegador.NewPageAsync();

            var resposta = await pagina.GotoAsync(
                "https://example.com");

            Assert.NotNull(resposta);
            Assert.True(resposta.Ok);
        }
    }
}


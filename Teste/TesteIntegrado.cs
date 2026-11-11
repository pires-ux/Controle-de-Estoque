

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
        public void Test1()
        {
            
        }
    }
}

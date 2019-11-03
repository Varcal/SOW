using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SOW.IntegrationTests.Config;
using SOW.WebApp;
using Xunit;

namespace SOW.IntegrationTests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class BancoTests
    {
        private readonly IntegtrationTestsFixture<StartupWebTests> _testsFixture;

        public BancoTests(IntegtrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Registrar banco com sucesso")]
        [Trait("Categoria", "Integração Web - Banco")]
        public async Task Banco_RegistrarNovo_DeveRegistrarComSucesso()
        {
            //Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Banco/Registrar");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgetyToken =
                _testsFixture.ObterAntiForgetFieldName(await initialResponse.Content.ReadAsStringAsync());

            var formData = new Dictionary<string, string>()
            {
                {"Numero", "341"},
                {"Nome", "Banco Itaú" },
                {_testsFixture.AntiForgeryFieldName, antiForgetyToken }
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Banco/Registrar")
            {
                 Content = new FormUrlEncodedContent(formData)
            };

            //Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);


            //Assert

            var responseString = await postResponse.Content.ReadAsStringAsync();

            postResponse.EnsureSuccessStatusCode();
            Assert.Contains("", responseString);
        }
    }
}

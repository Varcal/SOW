using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Testing;
using SOW.WebApp;
using Xunit;

namespace SOW.IntegrationTests.Config
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegtrationTestsFixture<StartupWebTests>> {  }


    public class IntegtrationTestsFixture<TStartup>: IDisposable where TStartup : class
    {
        public string AntiForgeryFieldName = "__RequestVerificationToken";
        public readonly SowWebAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegtrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions { };

            Factory = new SowWebAppFactory<TStartup>();
            Client = Factory.CreateClient();
        }

        public string ObterAntiForgetFieldName(string htmlBody)
        {

            var requestVerificationTokenMatch = Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFieldName}"" type=""hidden"" value=""([^""]+)"" \/\>");

            if (requestVerificationTokenMatch.Success)
            {
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;
            }

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFieldName}' not found in HTML", nameof(htmlBody));
        }

        public void Dispose()
        {
            Factory?.Dispose();
            Client?.Dispose();
        }
    }
}

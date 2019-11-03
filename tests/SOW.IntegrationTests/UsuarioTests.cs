using System;
using System.Collections.Generic;
using System.Text;
using SOW.IntegrationTests.Config;
using SOW.WebApp;

namespace SOW.IntegrationTests
{
    public class UsuarioTests
    {
        private readonly IntegtrationTestsFixture<StartupWebTests> _testsFixture;

        public UsuarioTests(IntegtrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }
    }
}

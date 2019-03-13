using SOW.Dominio.ObjetosDeValor;
using Xunit;

namespace SOW.Dominio.Testes.ObjetosDeValor
{
    public class NumeroContaTestes
    {
        private string _numero;

        public NumeroContaTestes()
        {
            _numero = "000000";
        }

        [Fact(DisplayName = "Deve criar NumeroConta")]
        [Trait("ObjetosDeValor", nameof(NumeroConta))]
        public void Deve_criar_NumeroConta()
        {
            var numeroConta = new NumeroConta(_numero);

            Assert.NotNull(numeroConta);
            Assert.Equal(_numero, numeroConta.Numero);
            Assert.Equal(_numero, numeroConta.ToString());
            Assert.True(numeroConta.EstaValido());
        }
    }
}

using SOW.Dominio.ObjetosDeValor;
using Xunit;

namespace SOW.Dominio.Testes.ObjetosDeValor
{
    public class NomeCompletoTestes
    {
        private string _nome;
        private string _sobrenome;

        public NomeCompletoTestes()
        {
            _nome = "Irving";
            _sobrenome = "Johnson";
        }


        [Fact(DisplayName = "Deve criar um NomeCompleto")]
        [Trait("ObjetosDeValor", nameof(NomeCompleto))]
        public void Deve_criar_NomeCompleto()
        {
            var nomeCompleto = new NomeCompleto(_nome, _sobrenome);

            Assert.NotNull(nomeCompleto);
            Assert.NotEmpty(nomeCompleto.Nome);
            Assert.NotEmpty(nomeCompleto.Sobrenome);
            Assert.Equal($"{_nome} {_sobrenome}", nomeCompleto.ToString());
        }

        [Fact(DisplayName = "Deve criar um NomeCompleto sem nome")]
        [Trait("ObjetosDeValor", nameof(NomeCompleto))]
        public void Nao_Deve_criar_NomeCompleto_sem_nome()
        {
            _nome = string.Empty;

            var nomeCompleto = new NomeCompleto(_nome, _sobrenome);

            Assert.False(nomeCompleto.EstaValido());
        }

        [Fact(DisplayName = "Deve criar um NomeCompleto sem sobrenome")]
        [Trait("ObjetosDeValor", nameof(NomeCompleto))]
        public void Nao_Deve_criar_NomeCompleto_sem_sobrenome()
        {
            _sobrenome = string.Empty;

            var nomeCompleto = new NomeCompleto(_nome, _sobrenome);

            Assert.False(nomeCompleto.EstaValido());
        }
    }
}

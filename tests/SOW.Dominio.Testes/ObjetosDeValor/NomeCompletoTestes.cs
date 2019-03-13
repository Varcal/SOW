using SOW.Dominio.ObjetosDeValor;
using Xunit;

namespace SOW.Dominio.Testes.ObjetosDeValor
{
    public class NomeCompletoTestes
    {
        private string _nome;

        public NomeCompletoTestes()
        {
            _nome = "Irving";
        }


        [Fact(DisplayName = "Deve criar um NomeCompleto")]
        [Trait("ObjetosDeValor", nameof(Nome))]
        public void Deve_criar_NomeCompleto()
        {
            var nome = new Nome(_nome);

            Assert.NotNull(nome);
            Assert.NotEmpty(nome.Value);
            Assert.Equal(_nome, nome.ToString());
        }

        [Fact(DisplayName = "Deve criar um NomeCompleto sem nome")]
        [Trait("ObjetosDeValor", nameof(Nome))]
        public void Nao_Deve_criar_NomeCompleto_sem_nome()
        {
            _nome = string.Empty;

            var nomeCompleto = new Nome(_nome);

            Assert.False(nomeCompleto.EstaValido());
        }

    }
}

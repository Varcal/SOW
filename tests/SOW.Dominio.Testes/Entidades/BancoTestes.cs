using SOW.Dominio.Entidades;
using Xunit;

namespace SOW.Dominio.Testes.Entidades
{
    public class BancoTestes
    {
        private string _numero;
        private string _nome;

        public BancoTestes()
        {
            _numero = "341";
            _nome = "Itaú";
        }

        [Fact(DisplayName = "Deve criar um banco")]
        [Trait("Dominio ", nameof(Banco))]
        public void Deve_criar_um_banco()
        {
            var banco = new Banco(_numero, _nome);

            Assert.NotNull(banco);
            Assert.Equal(_numero, banco.Numero);
            Assert.Equal(_nome, banco.Nome);
            Assert.True(banco.EstaValido());
        }

        [Fact(DisplayName = "Não deve criar um banco sem numero")]
        [Trait("Dominio ", nameof(Banco))]
        public void Nao_deve_criar_um_banco_sem_numero()
        {
            _numero = string.Empty;

            var banco = new Banco(_numero, _nome);

            Assert.False(banco.EstaValido());
        }


        [Fact(DisplayName = "Não deve criar um banco sem nome")]
        [Trait("Dominio ", nameof(Banco))]
        public void Nao_deve_criar_um_banco_sem_nome()
        {
            _nome = string.Empty;

            var banco = new Banco(_numero, _nome);

            Assert.False(banco.EstaValido());
        }
    }
}

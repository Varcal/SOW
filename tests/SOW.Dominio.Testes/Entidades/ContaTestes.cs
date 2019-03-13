using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;
using Xunit;

namespace SOW.Dominio.Testes.Entidades
{
    public class ContaTestes
    {
        private Banco _banco;
        private Saldo _saldo;

        public ContaTestes()
        {
            _banco = new Banco("341", "Itaú");
            _saldo = new Saldo(1000);
        }


        [Fact(DisplayName = "Deve criar uma conta")]
        [Trait("Dominio", nameof(Conta))]
        public void Deve_criar_uma_conta()
        {
            var conta = new Conta(_banco, _saldo);

            Assert.NotNull(conta);
            Assert.Equal(_banco, conta.Banco);
            Assert.Equal(_saldo, conta.Saldo);
            Assert.NotNull(conta.Numero);
            Assert.False(string.IsNullOrWhiteSpace(conta.Numero.ToString()));
            Assert.True(conta.EstaValida());
        }

        [Fact(DisplayName = "Não deve criar uma conta sem o banco")]
        [Trait("Dominio", nameof(Conta))]
        public void Nao_deve_criar_uma_conta_sem_o_banco()
        {
            _banco = null;

            var conta = new Conta(_banco, _saldo);

            Assert.False(conta.EstaValida());
        }


        [Fact(DisplayName = "Não deve criar uma conta sem saldo")]
        [Trait("Dominio", nameof(Conta))]
        public void Nao_deve_criar_uma_conta_sem_saldo()
        {
            _saldo = null;
            
            var conta = new Conta(_banco, _saldo);

            Assert.False(conta.EstaValida());
        }
    }
}

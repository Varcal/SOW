using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;
using Xunit;

namespace SOW.Dominio.Testes.Entidades
{
    public class UsuarioTestes
    {
        private Nome _nome;
        private readonly Saldo _saldo;
        private readonly Banco _banco;
        private Conta _conta;
        

        public UsuarioTestes()
        {
            _nome = new Nome("João");
            _saldo = new Saldo(1000.99M);
            _banco = new Banco("341", "Itáu");
            _conta = new Conta(_banco, _saldo);
        }


        [Fact(DisplayName = "Deve criar um usuario")]
        [Trait("Dominio", nameof(Usuario))]
        public void Deve_criar_um_usuario()
        {          
           var usuario = new Usuario(_nome, _conta);

           Assert.NotNull(usuario);
           Assert.Equal(_nome, usuario.Nome);
           Assert.Contains(_conta, usuario.Contas);
           Assert.True(usuario.EstaValido());
        }

        [Fact(DisplayName = "Não deve criar um usuario sem nome")]
        [Trait("Dominio", nameof(Usuario))]
        public void Nao_deve_criar_um_usuario_sem_nome()
        {
            _nome = null;

            var usuario = new Usuario(_nome, _conta);

            Assert.False(usuario.EstaValido());
        }

        [Fact(DisplayName = "Não deve criar um usuario sem conta")]
        [Trait("Dominio", nameof(Usuario))]
        public void Nao_deve_criar_um_usuario_sem_conta()
        {
            _conta = null;

            var usuario = new Usuario(_nome, _conta);

            Assert.False(usuario.EstaValido());
        }
    }
}

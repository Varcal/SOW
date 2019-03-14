using Moq;
using SOW.Dominio.Commands.Contas;
using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;
using SOW.Dominio.Repositorios;
using SOW.Dominio.Servicos;
using SOW.Dominio.Testes.Fakes;
using Xunit;

namespace SOW.Dominio.Testes.Servicos
{
    public class ContaServicoTestes
    {
        private readonly int _contaId;
        private decimal _valor;
        private readonly Conta _contaFake;
        private readonly Saldo _saldoAntigo;

        public ContaServicoTestes()
        {
            _contaId = 1;
            _valor = 99.99M;
            _contaFake = Fake.CriarConta();
            _saldoAntigo = _contaFake.Saldo;
        }

        [Fact(DisplayName = "Creditar valor em conta")]
        [Trait("Servico Dominio", nameof(MovimentacaoDominioServico))]
        public void Creditar_valor_em_conta()
        {
            var creditoCommand = new CreditoCommand(_contaId, _valor);

            var contaRepositorioMock = new Mock<IContaRepositorio>();
            contaRepositorioMock.Setup(c => c.ObterPorId(_contaId)).Returns(_contaFake);

            var contaServico = new MovimentacaoDominioServico(contaRepositorioMock.Object);
            contaServico.Creditar(creditoCommand);

            Assert.Equal(_saldoAntigo.Valor + _valor, _contaFake.Saldo.Valor);

        }

        [Fact(DisplayName = "Debitar valor em conta")]
        [Trait("Servico Dominio", nameof(MovimentacaoDominioServico))]
        public void Debitar_valor_em_conta()
        {
           
            var debitoCommand = new DebitoCommand(_contaId, _valor);

            var contaRepositorioMock = new Mock<IContaRepositorio>();
            contaRepositorioMock.Setup(c => c.ObterPorId(_contaId)).Returns(_contaFake);

            var contaServico = new MovimentacaoDominioServico(contaRepositorioMock.Object);
            contaServico.Debitar(debitoCommand);
  
            Assert.Equal(_saldoAntigo.Valor - _valor, _contaFake.Saldo.Valor);
        }

        [Fact(DisplayName = "Não debitar valor em conta se saldo insuficiente")]
        [Trait("Servico Dominio", nameof(MovimentacaoDominioServico))]
        public void Nao_debitar_valor_em_conta_se_saldo_insuficiente()
        {
            _valor = 1200;

            var debitoCommand = new DebitoCommand(_contaId, _valor);

            var contaRepositorioMock = new Mock<IContaRepositorio>();
            contaRepositorioMock.Setup(c => c.ObterPorId(_contaId)).Returns(_contaFake);
            contaRepositorioMock.Setup(c => c.Editar(_contaFake));

            var contaServico = new MovimentacaoDominioServico(contaRepositorioMock.Object);
            contaServico.Debitar(debitoCommand);
            
            Assert.Equal(_saldoAntigo, _contaFake.Saldo);
        }

        [Fact(DisplayName = "Transferir valor entre contas")]
        [Trait("Servico Dominio", nameof(MovimentacaoDominioServico))]
        public void Transeferir_valor_entre_contas()
        {
            var contaDebitoId = 1;
            var contaCreditoId = 2;
            var valor = 99.99M;
            var contaDebito = Fake.CriarConta();
            var saldoAnteriorContaDebito = contaDebito.Saldo;
            var contaCredito = Fake.CriarConta();
            var saldoAnteriorContaCredito = contaCredito.Saldo;
            var transferenciaCommand = new TransferenciaCommand(contaDebitoId, contaCreditoId, valor);

            var contaRepositorioMock = new Mock<IContaRepositorio>();
            contaRepositorioMock.Setup(c => c.ObterPorId(contaDebitoId)).Returns(contaDebito);
            contaRepositorioMock.Setup(c => c.ObterPorId(contaCreditoId)).Returns(contaCredito);

            var contaServico = new MovimentacaoDominioServico(contaRepositorioMock.Object);
            contaServico.Transferir(transferenciaCommand);
          
            Assert.Equal(saldoAnteriorContaDebito.Valor - valor, contaDebito.Saldo.Valor);
            Assert.Equal(saldoAnteriorContaCredito.Valor + valor, contaCredito.Saldo.Valor);
        }

        [Fact(DisplayName = "Não transferir valor entre contas se saldo insuficiente")]
        [Trait("Servico Dominio", nameof(MovimentacaoDominioServico))]
        public void Nao_Transeferir_valor_entre_contas_se_saldo_insuficiente()
        {
            var contaDebitoId = 1;
            var contaCreditoId = 2;
            var valor = 2099.99M;
            var contaDebito = Fake.CriarConta();
            var saldoAnteriorContaDebito = contaDebito.Saldo;
            var contaCredito = Fake.CriarConta();
            var saldoAnteriorContaCredito = contaCredito.Saldo;
            var transferenciaCommand = new TransferenciaCommand(contaDebitoId, contaCreditoId, valor);

            var contaRepositorioMock = new Mock<IContaRepositorio>();
            contaRepositorioMock.Setup(c => c.ObterPorId(contaDebitoId)).Returns(contaDebito);
            contaRepositorioMock.Setup(c => c.ObterPorId(contaCreditoId)).Returns(contaCredito);

            var contaServico = new MovimentacaoDominioServico(contaRepositorioMock.Object);
            contaServico.Transferir(transferenciaCommand);

            Assert.Equal(saldoAnteriorContaDebito.Valor, contaDebito.Saldo.Valor);
            Assert.Equal(saldoAnteriorContaCredito.Valor, contaCredito.Saldo.Valor);
        }
    }
}

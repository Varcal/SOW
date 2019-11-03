using SOW.Dominio.Commands.Contas;
using SOW.Dominio.Interfaces.Repositorios;
using SOW.Dominio.Interfaces.Servicos;
using SOW.NucleoCompartilhado.DomainEvents.Core;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;

namespace SOW.Dominio.Servicos
{
    public class MovimentacaoDominioServico: IMovimentacaoDominioServico
    {
        private readonly IContaRepositorio _contaRepositorio;

        public MovimentacaoDominioServico(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

        public void Creditar(CreditoCommand creditoCommand)
        {
            var conta = _contaRepositorio.ObterPorId(creditoCommand.ContaId);
            conta.Creditar(creditoCommand.Valor);
            _contaRepositorio.Editar(conta);            
        }

        public void Debitar(DebitoCommand debitoCommand)
        {
            var conta = _contaRepositorio.ObterPorId(debitoCommand.ContaId);

            if (conta.Saldo.Valor < debitoCommand.Valor)
            {
                DomainEvent.RaiseEvent(new DomainNotification("SaldoInsuficiente", "Saldo insuficiente"));
                return;
            }
                
            conta.Debitar(debitoCommand.Valor);
            _contaRepositorio.Editar(conta);
        }

        public void Transferir(TransferenciaCommand transferenciaCommand)
        {
            var contaDebito = _contaRepositorio.ObterPorId(transferenciaCommand.ContaDebitoId);

            if (contaDebito.Saldo.Valor < transferenciaCommand.Valor)
            {
                DomainEvent.RaiseEvent(new DomainNotification("SaldoInsuficiente", "Saldo insuficiente"));
                return;
            }

            var contaCredito = _contaRepositorio.ObterPorId(transferenciaCommand.ContaCreditoId);

            contaDebito.Debitar(transferenciaCommand.Valor);
            contaCredito.Creditar(transferenciaCommand.Valor);

            _contaRepositorio.Editar(contaDebito);
            _contaRepositorio.Editar(contaCredito);
        }
    }
}
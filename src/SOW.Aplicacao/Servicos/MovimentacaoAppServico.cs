using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.Servicos.Base;
using SOW.Dominio.Commands.Contas;
using SOW.Dominio.Interfaces.Servicos;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Aplicacao.Servicos
{
    public class MovimentacaoAppServico: AplicacaoServicoBase, IMovimentacaoAppServico
    {
        private readonly IMovimentacaoDominioServico _movimentacaoDominioServico;

        public MovimentacaoAppServico(IUnitOfWork uow, IMovimentacaoDominioServico movimentacaoDominioServico) : base(uow)
        {
            _movimentacaoDominioServico = movimentacaoDominioServico;
        }

        public void Debitar(DebitoCommand debitoCommand)
        {
            _movimentacaoDominioServico.Debitar(debitoCommand);
            Save();
        }

        public void Creditar(CreditoCommand creditoCommand)
        {
            _movimentacaoDominioServico.Creditar(creditoCommand);
            Save();
        }

        public void Transferir(TransferenciaCommand transferenciaCommand)
        {
            _movimentacaoDominioServico.Transferir(transferenciaCommand);
            Save();
        }
    }
}

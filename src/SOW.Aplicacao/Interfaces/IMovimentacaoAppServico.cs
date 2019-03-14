using SOW.Dominio.Commands.Contas;

namespace SOW.Aplicacao.Interfaces
{
    public interface IMovimentacaoAppServico
    {
        void Debitar(DebitoCommand debitoCommand);
        void Creditar(CreditoCommand creditoCommand);
        void Transferir(TransferenciaCommand transferenciaCommand);
    }
}

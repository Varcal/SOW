using SOW.Dominio.Commands.Contas;

namespace SOW.Dominio.Interfaces.Servicos
{
    public interface IMovimentacaoDominioServico
    {
        void Creditar(CreditoCommand creditoCommand);
        void Debitar(DebitoCommand debitoCommand);
        void Transferir(TransferenciaCommand transferenciaCommand);
    }
}

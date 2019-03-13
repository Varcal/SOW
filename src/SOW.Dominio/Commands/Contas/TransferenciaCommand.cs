namespace SOW.Dominio.Commands
{
    public class TransferenciaCommand
    {
        public int ContaDebitoId { get; private set; }
        public int ContaCreditoId { get; private set; }
        public decimal Valor { get; private set; }

        public TransferenciaCommand(int contaDebitoId, int contaCreditoId, decimal valor)
        {
            ContaDebitoId = contaDebitoId;
            ContaCreditoId = contaCreditoId;
            Valor = valor;
        }
    }
}

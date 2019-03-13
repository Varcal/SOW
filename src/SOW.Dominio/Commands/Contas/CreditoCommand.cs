namespace SOW.Dominio.Commands.Contas
{
    public class CreditoCommand
    {
        public int ContaId { get; set; }
        public decimal Valor { get; set; }

        public CreditoCommand(int contaId, decimal valor)
        {
            ContaId = contaId;
            Valor = valor;
        }
    }
}
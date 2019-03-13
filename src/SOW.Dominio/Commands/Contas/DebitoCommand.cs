namespace SOW.Dominio.Commands.Contas
{
    public class DebitoCommand
    {
        public int ContaId { get; set; }
        public decimal Valor { get; set; }

        public DebitoCommand(int contaId, decimal valor)
        {
            ContaId = contaId;
            Valor = valor;
        }
    }
}

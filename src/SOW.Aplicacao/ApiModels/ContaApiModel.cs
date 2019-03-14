using SOW.Dominio.Entidades;

namespace SOW.Aplicacao.ApiModels
{
    public class ContaApiModel
    {
        public int Id { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public decimal SaldoAtual { get; set; }

        public ContaApiModel(Conta conta)
        {
            Id = conta.Id;
            Banco = conta.Banco.Nome;
            Numero = conta.ContaCorrente.Numero;
            SaldoAtual = conta.Saldo.Valor;
        }
    }
}

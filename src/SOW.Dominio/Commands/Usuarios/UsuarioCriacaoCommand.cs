
namespace SOW.Dominio.Commands.Usuarios
{
    public sealed class UsuarioCriacaoCommand
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public int BancoId { get; private set; }
        public decimal SaldoInicial { get; set; }
    }
}

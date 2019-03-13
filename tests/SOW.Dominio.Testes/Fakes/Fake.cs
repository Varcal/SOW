using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;

namespace SOW.Dominio.Testes.Fakes
{
    public class Fake
    {
        public static Conta CriarConta()
        {
            var conta = new Conta(new Banco("341", "Itau"), new Saldo(1000));
            conta.SetProperty(x=>x.Id, 1);

            return conta;
        }

        public static Conta CriarConta(int id)
        {
            var conta = new Conta(new Banco("341", "Itau"), new Saldo(1000));
            conta.SetProperty(x => x.Id, id);

            return conta;
        }
    }
}

using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.ObjetosDeValor
{
    public sealed class Saldo: ObjetoValor
    {
        public decimal Valor { get; private set; }

        public Saldo(decimal valor)
        {
            Valor = valor;
        }
    }

}

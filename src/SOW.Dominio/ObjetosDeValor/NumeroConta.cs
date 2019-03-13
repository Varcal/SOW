using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.ObjetosDeValor
{
    public sealed class NumeroConta: ObjetoValor
    {
        public string Numero { get; private set; }

        public NumeroConta(string numero)
        {
            Numero = numero;
            EstaValido();
        }

        public override string ToString()
        {
            return Numero;
        }

        public bool EstaValido()
        {
            return this.CriarNumeroContaSeValido();
        }
    }

}

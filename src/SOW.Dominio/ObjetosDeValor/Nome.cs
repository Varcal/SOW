using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.ObjetosDeValor
{
    public sealed class Nome: ObjetoValor
    {
        public string Value { get; private set; }

        private Nome()
        {
            
        }

        public Nome(string nome)
        {
            Value = nome;
            EstaValido();
        }

        public override string ToString()
        {
            return Value;
        }

        public bool EstaValido()
        {
            return this.CriarNomeCompletoSeValido();
        }
    }
}

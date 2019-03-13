using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.ObjetosDeValor
{
    public sealed class NomeCompleto: ObjetoValor
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            EstaValido();
        }

        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }

        public bool EstaValido()
        {
            return this.CriarNomeCompletoSeValido();
        }
    }
}

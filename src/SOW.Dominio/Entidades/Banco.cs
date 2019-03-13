using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.Entidades
{
    public sealed class Banco: Entidade
    {
        public string Numero { get; set; }
        public string Nome { get; set; }


        private Banco() { }

        public Banco(string numero, string nome)
        {
            Numero = numero;
            Nome = nome;
            EstaValido();
        }

        public bool EstaValido()
        {
            return this.CriarBancoSeValido();
        }
    }

}

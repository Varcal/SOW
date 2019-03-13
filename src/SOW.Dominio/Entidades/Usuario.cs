using System.Collections.Generic;
using SOW.Dominio.ObjetosDeValor;
using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.Entidades
{
    public sealed class Usuario : Entidade
    {
        public NomeCompleto Nome { get; set; }
        public IList<Conta> Contas { get; private set; } = new List<Conta>();


        private Usuario() { }
        public Usuario(NomeCompleto nome, Conta conta)
        {
            Nome = nome;
            AdicionarConta(conta);
            EstaValido();
        }

        public bool EstaValido()
        {
            return this.CriarUsuarioSeValido();
        }

        public void AdicionarConta(Conta conta)
        {
            if (conta != null)
                Contas.Add(conta);
        }
    }
}

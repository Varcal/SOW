using System;
using SOW.Dominio.ObjetosDeValor;
using SOW.Dominio.Scopes;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.Entidades
{
    public sealed class Conta: Entidade
    {
        public int BancoId { get; private set; }
        public Banco Banco { get; private set; }
        public NumeroConta Numero { get; private set; }
        public Saldo Saldo { get; private set; }
        public int UsuarioId { get; private set; }


        private Conta() { }

        public Conta(Banco banco, Saldo saldo)
        {
            Banco = banco;
            Numero = new NumeroConta(GerarNumeroConta());
            Saldo = saldo;
        }

        public void Creditar(decimal valor)
        {
            Saldo = new Saldo(Saldo.Valor + valor);
        }

        public void Debitar(decimal valor)
        {
            Saldo = new Saldo(Saldo.Valor - valor);
        }

        private string GerarNumeroConta()
        {
            var numero = new Random().Next(999999).ToString().PadLeft(6,'0');
            return numero;
        }

        public bool EstaValida()
        {
            return this.CriarContaSeValida();
        }
    }
}

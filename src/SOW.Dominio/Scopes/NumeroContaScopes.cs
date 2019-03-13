using SOW.Dominio.ObjetosDeValor;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class NumeroContaScopes
    {
        public static bool CriarNumeroContaSeValido(this NumeroConta numeroConta)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaVazioOuNulo(numeroConta.Numero, "Número é obrigatorio"),
                    ValidarSe.SaoIguais(6, numeroConta.Numero.Length, "Número da conta deve conter 6 dígitos")
                );
        }
    }
}

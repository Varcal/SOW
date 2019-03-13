using SOW.Dominio.Entidades;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class ContaScopes
    {
        public static bool CriarContaSeValida(this Conta conta)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaNulo(conta.ContaCorrente, "Número da conta é obrigatório"),
                    ValidarSe.NaoEstaNulo(conta.Banco, "Banco é obrigatório"),
                    ValidarSe.NaoEstaNulo(conta.Saldo, "Saldo é obrigatório"),
                    ValidarSe.Verdadeiro(conta.ContaCorrente.EstaValido(), "Número da conta deve ser válido")
                );
        }
    }
}

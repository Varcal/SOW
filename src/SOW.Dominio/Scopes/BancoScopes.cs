using SOW.Dominio.Entidades;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class BancoScopes
    {
        public static bool CriarBancoSeValido(this Banco banco)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaVazioOuNulo(banco.Numero, "Número do banco é obrigatório"),
                    ValidarSe.SaoIguais(3, banco.Numero.Length, "Número do banco deve conter 3 caracteres"),
                    ValidarSe.NaoEstaVazioOuNulo(banco.Nome, "Nome do banco é obrigatório")
                        );
        }
    }
}

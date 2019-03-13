using SOW.Dominio.ObjetosDeValor;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class NomeCompletoScopes
    {
        public static bool CriarNomeCompletoSeValido(this Nome nome)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaVazioOuNulo(nome.Value, "Nome é obrigatório")
                );
        }
    }
}

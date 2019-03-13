using SOW.Dominio.ObjetosDeValor;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class NomeCompletoScopes
    {
        public static bool CriarNomeCompletoSeValido(this NomeCompleto nomeCompleto)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaVazioOuNulo(nomeCompleto.Nome, "Nome é obrigatório"),
                    ValidarSe.NaoEstaVazioOuNulo(nomeCompleto.Sobrenome, "Sobrenome é obrigatório")
                );
        }
    }
}

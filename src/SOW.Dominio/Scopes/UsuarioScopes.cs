using System.Linq;
using SOW.Dominio.Entidades;
using SOW.NucleoCompartilhado.Validacoes;
using SOW.NucleoCompartilhado.Validacoes.Base;

namespace SOW.Dominio.Scopes
{
    public static class UsuarioScopes
    {
        public static bool CriarUsuarioSeValido(this Usuario usuario)
        {
            return GarantirQue.EstaValido(
                    ValidarSe.NaoEstaNulo(usuario.Nome, "Nome é obrigatório"),
                    ValidarSe.Verdadeiro(usuario.Nome?.EstaValido() ?? false, "Nome está inválido"),
                    ValidarSe.Verdadeiro(usuario.Contas.Any(), "Conta é obrigatória")
                );
        }
    }
}

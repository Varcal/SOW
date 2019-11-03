using System.Collections.Generic;
using SOW.Dominio.Entidades;
using SOW.Dominio.Interfaces.Repositorios.Base;

namespace SOW.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        IReadOnlyList<Usuario> SelecionarTodos();
        Conta ObterConta(int usuarioId);
    }
}

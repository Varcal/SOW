using System.Collections.Generic;
using SOW.Dominio.Entidades;
using SOW.Dominio.Interfaces.Repositorios.Base;

namespace SOW.Dominio.Interfaces.Repositorios
{
    public interface IBancoRepositorio: IRepositorioBase<Banco>
    {
        Banco ObterPorId(int bancoId);
        IReadOnlyList<Banco> SelecionarTodos();
    }
}

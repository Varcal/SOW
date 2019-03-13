using SOW.Dominio.Entidades;
using SOW.Dominio.Repositorios.Base;

namespace SOW.Dominio.Repositorios
{
    public interface IBancoRepositorio: IRepositorioBase<Banco>
    {
        Banco ObterPorId(int bancoId);
    }
}

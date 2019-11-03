using SOW.Dominio.Entidades;
using SOW.Dominio.Interfaces.Repositorios.Base;

namespace SOW.Dominio.Interfaces.Repositorios
{
    public interface IContaRepositorio: IRepositorioBase<Conta>
    {
        Conta ObterPorId(int id);
    }
}

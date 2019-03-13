using SOW.Dominio.Entidades;
using SOW.Dominio.Repositorios.Base;

namespace SOW.Dominio.Repositorios
{
    public interface IContaRepositorio: IRepositorioBase<Conta>
    {
        Conta ObterPorId(int id);
    }
}

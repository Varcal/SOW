using SOW.Dominio.Interfaces.Repositorios.Base;
using SOW.Infra.Dados.Contextos;
using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Infra.Dados.Repositorios.Base
{
    public abstract class RepositorioBase<T>: IRepositorioBase<T> where T: Entidade
    {
        protected readonly EfContext EfContext;

        protected RepositorioBase(EfContext efContext)
        {
            EfContext = efContext;
        }

        public void Adicionar(T entidade)
        {
            EfContext.Set<T>().Add(entidade);
        }

        public void Editar(T entidade)
        {
            EfContext.Set<T>().Update(entidade);
        }

        public void Excluir(T entidade)
        {
            EfContext.Set<T>().Remove(entidade);
        }
    }
}

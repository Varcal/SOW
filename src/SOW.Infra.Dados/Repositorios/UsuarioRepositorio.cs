using SOW.Dominio.Entidades;
using SOW.Dominio.Repositorios;
using SOW.Infra.Dados.Contextos;
using SOW.Infra.Dados.Repositorios.Base;

namespace SOW.Infra.Dados.Repositorios
{
    public class UsuarioRepositorio:RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(EfContext efContext) 
            : base(efContext)
        {
        }
    }
}

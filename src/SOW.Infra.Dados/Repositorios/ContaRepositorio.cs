using System.Linq;
using Microsoft.EntityFrameworkCore;
using SOW.Dominio.Entidades;
using SOW.Dominio.Interfaces.Repositorios;
using SOW.Infra.Dados.Contextos;
using SOW.Infra.Dados.Repositorios.Base;

namespace SOW.Infra.Dados.Repositorios
{
    public sealed class ContaRepositorio:RepositorioBase<Conta>, IContaRepositorio
    {

        public ContaRepositorio(EfContext efContext)
            :base(efContext)
        {
        }

        public Conta ObterPorId(int id)
        {
            return EfContext.Contas
                .Include(x=>x.Saldo)
                .Include(x=>x.ContaCorrente)
                .FirstOrDefault(x=>x.Id == id);
        }
    }
}

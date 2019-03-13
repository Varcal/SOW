using Microsoft.Extensions.DependencyInjection;
using SOW.Dominio.Repositorios;
using SOW.Infra.Dados.Contextos;
using SOW.Infra.Dados.Repositorios;
using SOW.Infra.Dados.Transacoes;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Infra.IoC
{
    public sealed class IoCConfig
    {
        public static void Initializer(IServiceCollection services)
        {
            services.AddDbContext<EfContext>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IBancoRepositorio, BancoRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

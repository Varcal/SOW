using Microsoft.Extensions.DependencyInjection;
using SOW.Aplicacao.Interfaces;
using SOW.Aplicacao.Servicos;
using SOW.Dominio.Interfaces.Repositorios;
using SOW.Dominio.Interfaces.Servicos;
using SOW.Dominio.Servicos;
using SOW.Infra.Dados.Contextos;
using SOW.Infra.Dados.Repositorios;
using SOW.Infra.Dados.Transacoes;
using SOW.NucleoCompartilhado.DomainEvents.Core;
using SOW.NucleoCompartilhado.DomainEvents.Notifications;
using SOW.NucleoCompartilhado.Transacacoes;

namespace SOW.Infra.IoC
{
    public sealed class IoCConfig
    {
        public static void Initializer(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            DomainEvent.ServiceProvider = services.BuildServiceProvider();

            services.AddDbContext<EfContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IBancoRepositorio, BancoRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();

            services.AddScoped<IMovimentacaoDominioServico, MovimentacaoDominioServico>();

            services.AddScoped<IBancoAppServico, BancoAppServico>();
            services.AddScoped<IUsuarioAppServico, UsuarioAppServico>();
            services.AddScoped<IMovimentacaoAppServico, MovimentacaoAppServico>();
        }
    }
}

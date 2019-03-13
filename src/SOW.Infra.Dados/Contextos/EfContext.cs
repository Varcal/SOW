using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SOW.Dominio.Entidades;
using SOW.Infra.Dados.Mapemanetos;

namespace SOW.Infra.Dados.Contextos
{
    public sealed class EfContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Conta> Contas { get; set; }


        public EfContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SOWConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new ContaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

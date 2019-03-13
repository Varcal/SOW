using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;

namespace SOW.Infra.Dados.Mapemanetos
{
    public sealed class UsuarioMap: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Contas)
                .WithOne()
                .HasForeignKey(x => x.UsuarioId);

            builder.OwnsOne<NomeCompleto>(p => p.Nome, config =>
            {
                config.Property(x => x.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(50)")
                    .IsRequired();
                config.Property(x => x.Sobrenome)
                    .HasColumnName("Sobrenome")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });
        }
    }
}

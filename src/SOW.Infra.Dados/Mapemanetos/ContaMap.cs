using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOW.Dominio.Entidades;
using SOW.Dominio.ObjetosDeValor;

namespace SOW.Infra.Dados.Mapemanetos
{
    public sealed class ContaMap: IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta", "dbo");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Banco)
                .WithMany()
                .HasForeignKey(x => x.BancoId);

            builder.OwnsOne<Saldo>(x => x.Saldo, config =>
            {
                config.Property(x => x.Valor)
                    .HasColumnName("Saldo")
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            builder.OwnsOne<NumeroConta>(x => x.Numero, config =>
            {
                config.Property(x => x.Numero)
                    .HasColumnName("Numero")
                    .HasColumnType("char(6)")
                    .IsRequired();
            });
        }
    }
}

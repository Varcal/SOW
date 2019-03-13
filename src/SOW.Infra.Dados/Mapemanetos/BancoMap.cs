using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SOW.Dominio.Entidades;

namespace SOW.Infra.Dados.Mapemanetos
{
    public sealed class BancoMap: IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("Banco","dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasColumnType("char(3)")
                .IsRequired();
            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}

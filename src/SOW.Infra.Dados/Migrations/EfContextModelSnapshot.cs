﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SOW.Infra.Dados.Contextos;

namespace SOW.Infra.Dados.Migrations
{
    [DbContext(typeof(EfContext))]
    partial class EfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SOW.Dominio.Entidades.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("char(3)");

                    b.HasKey("Id");

                    b.ToTable("Banco","dbo");
                });

            modelBuilder.Entity("SOW.Dominio.Entidades.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Conta","dbo");
                });

            modelBuilder.Entity("SOW.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Usuario","dbo");
                });

            modelBuilder.Entity("SOW.Dominio.Entidades.Conta", b =>
                {
                    b.HasOne("SOW.Dominio.Entidades.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SOW.Dominio.Entidades.Usuario")
                        .WithMany("Contas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("SOW.Dominio.ObjetosDeValor.NumeroConta", "Numero", b1 =>
                        {
                            b1.Property<int>("ContaId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Numero")
                                .HasColumnType("char(6)");

                            b1.HasKey("ContaId");

                            b1.ToTable("Conta","dbo");

                            b1.HasOne("SOW.Dominio.Entidades.Conta")
                                .WithOne("Numero")
                                .HasForeignKey("SOW.Dominio.ObjetosDeValor.NumeroConta", "ContaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("SOW.Dominio.ObjetosDeValor.Saldo", "Saldo", b1 =>
                        {
                            b1.Property<int>("ContaId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Valor")
                                .HasColumnName("Saldo")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ContaId");

                            b1.ToTable("Conta","dbo");

                            b1.HasOne("SOW.Dominio.Entidades.Conta")
                                .WithOne("Saldo")
                                .HasForeignKey("SOW.Dominio.ObjetosDeValor.Saldo", "ContaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SOW.Dominio.Entidades.Usuario", b =>
                {
                    b.OwnsOne("SOW.Dominio.ObjetosDeValor.Nome", "Nome", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnName("Nome")
                                .HasColumnType("varchar(50)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario","dbo");

                            b1.HasOne("SOW.Dominio.Entidades.Usuario")
                                .WithOne("Nome")
                                .HasForeignKey("SOW.Dominio.ObjetosDeValor.Nome", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

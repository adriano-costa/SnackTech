﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SnackTech.Driver.DataBase.Context;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace SnackTech.Driver.DataBase.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [ExcludeFromCodeCoverage]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("smallmoney");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItem", (string)null);
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Valor")
                        .HasColumnType("smallmoney");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Cliente", b =>
                {
                    b.HasBaseType("SnackTech.Driver.DataBase.Entities.Pessoa");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Cliente", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6ee54a46-007f-4e4c-9fe8-1a13eadf7fd1"),
                            Nome = "Cliente Padrão",
                            Cpf = "00000000191",
                            Email = "cliente.padrao@padrao.com"
                        });
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Pedido", b =>
                {
                    b.HasOne("SnackTech.Driver.DataBase.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.PedidoItem", b =>
                {
                    b.HasOne("SnackTech.Driver.DataBase.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SnackTech.Driver.DataBase.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Cliente", b =>
                {
                    b.HasOne("SnackTech.Driver.DataBase.Entities.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("SnackTech.Driver.DataBase.Entities.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SnackTech.Driver.DataBase.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}

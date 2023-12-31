﻿// <auto-generated />
using System;
using CleanGrassAppWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanGrassAppWeb.DataMigrations
{
    [DbContext(typeof(CleanGrassDbContext))]
    [Migration("20231215212754_AdicionarRelacionamentoServicoCategoria")]
    partial class AdicionarRelacionamentoServicoCategoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CategoriaServico", b =>
                {
                    b.Property<int>("CategoriasCategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServicosServicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriasCategoriaId", "ServicosServicoId");

                    b.HasIndex("ServicosServicoId");

                    b.ToTable("CategoriaServico");
                });

            modelBuilder.Entity("CleanGrassAppWeb.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("CleanGrassAppWeb.Models.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MarcaId");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("CleanGrassAppWeb.Models.Servico", b =>
                {
                    b.Property<int>("ServicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("JardineiroProfissional")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("ServicoId");

                    b.HasIndex("MarcaId");

                    b.ToTable("TBL_SERVICO");
                });

            modelBuilder.Entity("CategoriaServico", b =>
                {
                    b.HasOne("CleanGrassAppWeb.Models.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanGrassAppWeb.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CleanGrassAppWeb.Models.Servico", b =>
                {
                    b.HasOne("CleanGrassAppWeb.Models.Marca", null)
                        .WithMany("Servicos")
                        .HasForeignKey("MarcaId");
                });

            modelBuilder.Entity("CleanGrassAppWeb.Models.Marca", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}

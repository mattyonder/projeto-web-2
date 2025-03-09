﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlataformaVoluntariado.Data;

#nullable disable

namespace PlataformaVoluntariado.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlataformaVoluntariado.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.HabilidadeAtividade", b =>
                {
                    b.Property<int>("AtividadeId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.HasKey("AtividadeId", "HabilidadeId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("HabilidadesAtividades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Instituicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaAtuacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.VoluntarioAtividade", b =>
                {
                    b.Property<int>("AtividadeId")
                        .HasColumnType("int");

                    b.Property<int>("VoluntarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInscricaoAtividade")
                        .HasColumnType("datetime2");

                    b.HasKey("AtividadeId", "VoluntarioId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("VoluntariosAtividades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.VoluntarioHabilidade", b =>
                {
                    b.Property<int>("VoluntarioId")
                        .HasColumnType("int");

                    b.Property<int>("HabilidadeId")
                        .HasColumnType("int");

                    b.HasKey("VoluntarioId", "HabilidadeId");

                    b.HasIndex("HabilidadeId");

                    b.ToTable("VoluntariosHabilidades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Atividade", b =>
                {
                    b.HasOne("PlataformaVoluntariado.Models.Instituicao", "Instituicao")
                        .WithMany("Atividades")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.HabilidadeAtividade", b =>
                {
                    b.HasOne("PlataformaVoluntariado.Models.Atividade", "Atividade")
                        .WithMany("HabilidadeAtividades")
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlataformaVoluntariado.Models.Habilidade", "Habilidade")
                        .WithMany("HabilidadeAtividades")
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atividade");

                    b.Navigation("Habilidade");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.VoluntarioAtividade", b =>
                {
                    b.HasOne("PlataformaVoluntariado.Models.Atividade", "Atividade")
                        .WithMany("VoluntarioAtividades")
                        .HasForeignKey("AtividadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlataformaVoluntariado.Models.Voluntario", "Voluntario")
                        .WithMany("VoluntarioAtividades")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atividade");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.VoluntarioHabilidade", b =>
                {
                    b.HasOne("PlataformaVoluntariado.Models.Habilidade", "Habilidade")
                        .WithMany("VoluntarioHabilidades")
                        .HasForeignKey("HabilidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlataformaVoluntariado.Models.Voluntario", "Voluntario")
                        .WithMany("VoluntarioHabilidades")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habilidade");

                    b.Navigation("Voluntario");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Atividade", b =>
                {
                    b.Navigation("HabilidadeAtividades");

                    b.Navigation("VoluntarioAtividades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Habilidade", b =>
                {
                    b.Navigation("HabilidadeAtividades");

                    b.Navigation("VoluntarioHabilidades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Instituicao", b =>
                {
                    b.Navigation("Atividades");
                });

            modelBuilder.Entity("PlataformaVoluntariado.Models.Voluntario", b =>
                {
                    b.Navigation("VoluntarioAtividades");

                    b.Navigation("VoluntarioHabilidades");
                });
#pragma warning restore 612, 618
        }
    }
}

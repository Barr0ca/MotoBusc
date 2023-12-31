﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ava2Bim.Context;

#nullable disable

namespace ava2Bim.Migrations
{
    [DbContext(typeof(ava2BimContext))]
    [Migration("20231107124333_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ava2Bim.Model.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .HasColumnType("text");

                    b.Property<string>("Whatsapp")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ava2Bim.Model.Motoqueiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Motoqueiros");
                });

            modelBuilder.Entity("ava2Bim.Model.Motoqueiro", b =>
                {
                    b.HasOne("ava2Bim.Model.Empresa", null)
                        .WithMany("Motoqueiros")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("ava2Bim.Model.Empresa", b =>
                {
                    b.Navigation("Motoqueiros");
                });
#pragma warning restore 612, 618
        }
    }
}

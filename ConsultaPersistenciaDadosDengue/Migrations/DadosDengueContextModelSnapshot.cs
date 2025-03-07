﻿// <auto-generated />
using ConsultaPersistenciaDadosDengue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultaPersistenciaDadosDengue.Migrations
{
    [DbContext(typeof(DadosDengueContext))]
    partial class DadosDengueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ConsultaPersistenciaDadosDengue.Models.DadosDengueModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("casos")
                        .HasColumnType("int");

                    b.Property<double>("casos_est")
                        .HasColumnType("double");

                    b.Property<int>("nivel")
                        .HasColumnType("int");

                    b.Property<int>("se")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("DadosDengue");
                });
#pragma warning restore 612, 618
        }
    }
}

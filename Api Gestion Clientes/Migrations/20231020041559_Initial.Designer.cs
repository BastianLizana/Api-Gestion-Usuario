﻿// <auto-generated />
using System;
using Api_Gestion_Clientes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_Gestion_Clientes.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231020041559_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Api_Gestion_Clientes.Data.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Api_Gestion_Clientes.Data.Logging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Log")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("fechaLog")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
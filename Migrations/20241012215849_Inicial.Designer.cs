﻿// <auto-generated />
using System;
using AlmaRosa_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlmaRosa_Ap1_P1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241012215849_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Cobro", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Cobros");

                    b.HasData(
                        new
                        {
                            CobroId = 1,
                            DeudorId = 1,
                            Fecha = new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2000m
                        },
                        new
                        {
                            CobroId = 2,
                            DeudorId = 2,
                            Fecha = new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 3000m
                        });
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.CobroDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ValorCobrado")
                        .HasColumnType("TEXT");

                    b.HasKey("DetalleId");

                    b.HasIndex("CobroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CobroDetalles");

                    b.HasData(
                        new
                        {
                            DetalleId = 1,
                            CobroId = 1,
                            PrestamoId = 1,
                            ValorCobrado = 1000m
                        },
                        new
                        {
                            DetalleId = 2,
                            CobroId = 2,
                            PrestamoId = 2,
                            ValorCobrado = 2000m
                        });
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DeudorId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Deudor A"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Deudor B"
                        });
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeudorId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");

                    b.HasData(
                        new
                        {
                            PrestamoId = 1,
                            Balance = 3000m,
                            Concepto = "Carro",
                            DeudorId = 1,
                            Monto = 5000m
                        },
                        new
                        {
                            PrestamoId = 2,
                            Balance = 5000m,
                            Concepto = "Carro",
                            DeudorId = 2,
                            Monto = 7000m
                        });
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Cobro", b =>
                {
                    b.HasOne("AlmaRosa_Ap1_P1.Models.Deudores", "deudores")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deudores");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.CobroDetalle", b =>
                {
                    b.HasOne("AlmaRosa_Ap1_P1.Models.Cobro", "Cobro")
                        .WithMany("CobrosDetalles")
                        .HasForeignKey("CobroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlmaRosa_Ap1_P1.Models.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cobro");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Prestamo", b =>
                {
                    b.HasOne("AlmaRosa_Ap1_P1.Models.Deudores", "deudores")
                        .WithMany("Prestamos")
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deudores");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Cobro", b =>
                {
                    b.Navigation("CobrosDetalles");
                });

            modelBuilder.Entity("AlmaRosa_Ap1_P1.Models.Deudores", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parqueadero.Contexts;

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210126131040_First-One")]
    partial class FirstOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Parqueadero.Entities.clsCobro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Hora_Ingreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora_Salida")
                        .HasColumnType("datetime2");

                    b.Property<short>("Parqueadero")
                        .HasColumnType("smallint");

                    b.Property<int>("ValorTotal")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("Parqueadero.Entities.clsParqueadero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Disponible")
                        .HasColumnType("int");

                    b.Property<int>("TipoVehiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parqueaderos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 2,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 3,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 4,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 5,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 6,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 7,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 8,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 9,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 10,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 11,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 12,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 13,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 14,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 15,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 16,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 17,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 18,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 19,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 20,
                            Disponible = 1,
                            TipoVehiculo = 0
                        },
                        new
                        {
                            Id = 21,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 22,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 23,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 24,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 25,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 26,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 27,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 28,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 29,
                            Disponible = 1,
                            TipoVehiculo = 1
                        },
                        new
                        {
                            Id = 30,
                            Disponible = 1,
                            TipoVehiculo = 1
                        });
                });

            modelBuilder.Entity("Parqueadero.Entities.clsPicoPlaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<short>("Numero")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("PicoPlacas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dia = 1,
                            Numero = (short)0
                        },
                        new
                        {
                            Id = 2,
                            Dia = 1,
                            Numero = (short)1
                        },
                        new
                        {
                            Id = 3,
                            Dia = 2,
                            Numero = (short)2
                        },
                        new
                        {
                            Id = 4,
                            Dia = 2,
                            Numero = (short)3
                        },
                        new
                        {
                            Id = 5,
                            Dia = 3,
                            Numero = (short)4
                        },
                        new
                        {
                            Id = 6,
                            Dia = 3,
                            Numero = (short)5
                        },
                        new
                        {
                            Id = 7,
                            Dia = 4,
                            Numero = (short)6
                        },
                        new
                        {
                            Id = 8,
                            Dia = 4,
                            Numero = (short)7
                        },
                        new
                        {
                            Id = 9,
                            Dia = 5,
                            Numero = (short)8
                        },
                        new
                        {
                            Id = 10,
                            Dia = 5,
                            Numero = (short)9
                        },
                        new
                        {
                            Id = 11,
                            Dia = 6,
                            Numero = (short)0
                        },
                        new
                        {
                            Id = 12,
                            Dia = 6,
                            Numero = (short)1
                        },
                        new
                        {
                            Id = 13,
                            Dia = 6,
                            Numero = (short)2
                        },
                        new
                        {
                            Id = 14,
                            Dia = 6,
                            Numero = (short)3
                        },
                        new
                        {
                            Id = 15,
                            Dia = 6,
                            Numero = (short)4
                        },
                        new
                        {
                            Id = 16,
                            Dia = 0,
                            Numero = (short)5
                        },
                        new
                        {
                            Id = 17,
                            Dia = 0,
                            Numero = (short)6
                        },
                        new
                        {
                            Id = 18,
                            Dia = 0,
                            Numero = (short)7
                        },
                        new
                        {
                            Id = 19,
                            Dia = 0,
                            Numero = (short)8
                        },
                        new
                        {
                            Id = 20,
                            Dia = 0,
                            Numero = (short)9
                        });
                });

            modelBuilder.Entity("Parqueadero.Entities.clsVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cilindraje")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("TipoVehiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Parqueadero.Entities.clsCobro", b =>
                {
                    b.HasOne("Parqueadero.Entities.clsVehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}

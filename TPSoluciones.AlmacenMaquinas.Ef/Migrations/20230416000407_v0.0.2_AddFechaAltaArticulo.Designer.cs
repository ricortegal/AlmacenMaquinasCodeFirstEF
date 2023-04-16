﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPSoluciones.AlmacenMaquinas.Ef.Contexto;

#nullable disable

namespace TPSoluciones.AlmacenMaquinas.Ef.Migrations
{
    [DbContext(typeof(AlmacenMaquinasDbContext))]
    [Migration("20230416000407_v0.0.2_AddFechaAltaArticulo")]
    partial class v002_AddFechaAltaArticulo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.AlmacenUbicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<string>("Estanteria")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaSalida")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Pasillo")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("almacen_ubicaciones", (string)null);
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Articulo", b =>
                {
                    b.Property<string>("NumSerie")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("FechaFabricacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaInstalacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaRecepcion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUbicacion")
                        .HasColumnType("int");

                    b.Property<string>("NotasFabricacion")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("NotasInstalacion")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("NotasRecepcion")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.HasKey("NumSerie");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdUbicacion");

                    b.ToTable("articulos", (string)null);
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("Poblacion")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TINYTEXT");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("productos", (string)null);
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("NumSerieArticulo")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("NumSerieArticulo")
                        .IsUnique();

                    b.ToTable("ventas", (string)null);
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Articulo", b =>
                {
                    b.HasOne("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Producto", "Producto")
                        .WithMany("Articulos")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPSoluciones.AlmacenMaquinas.Ef.Entidades.AlmacenUbicacion", "Ubicacion")
                        .WithMany("Articulos")
                        .HasForeignKey("IdUbicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Venta", b =>
                {
                    b.HasOne("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Articulo", "Articulo")
                        .WithOne("Venta")
                        .HasForeignKey("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Venta", "NumSerieArticulo");

                    b.Navigation("Articulo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.AlmacenUbicacion", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Articulo", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("TPSoluciones.AlmacenMaquinas.Ef.Entidades.Producto", b =>
                {
                    b.Navigation("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
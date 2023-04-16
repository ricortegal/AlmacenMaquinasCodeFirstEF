using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TPSoluciones.AlmacenMaquinas.Ef.Entidades;

namespace TPSoluciones.AlmacenMaquinas.Ef.Contexto
{
    public class AlmacenMaquinasDbContext : DbContext, IAlmacenMaquinasDbContext
    {


        public AlmacenMaquinasDbContext()
            : base()
        {

        }


        public AlmacenMaquinasDbContext(DbContextOptions<AlmacenMaquinasDbContext> options)
            : base(options) 
        {
        }


        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<AlmacenUbicacion> Ubicaciones { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;User=root;Password=alberto01;Database=maquinasalmacen;",
                                    new MariaDbServerVersion("10.11.2"))
                          .EnableSensitiveDataLogging(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Articulo

            modelBuilder.Entity<Articulo>().ToTable("articulos");

            modelBuilder.Entity<Articulo>()
                        .Property(p => p.NumSerie)
                            .HasMaxLength(15)
                            .IsRequired();

            modelBuilder.Entity<Articulo>()
                    .HasOne(a => a.Producto)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(a => a.IdProducto);

            modelBuilder.Entity<Articulo>()
                        .HasOne(a => a.Ubicacion)
                        .WithMany(al => al.Articulos)
                        .HasForeignKey(al => al.IdUbicacion);

            modelBuilder.Entity<Articulo>()
                        .Property(a => a.NotasFabricacion)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Articulo>()
                        .Property(a => a.NotasRecepcion)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Articulo>()
                        .Property(a => a.NotasInstalacion)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Articulo>().HasKey(e => e.NumSerie);



            //AlmacenUbicacion

            modelBuilder.Entity<AlmacenUbicacion>().ToTable("almacen_ubicaciones");

            modelBuilder.Entity<AlmacenUbicacion>()
                        .Property(a => a.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<AlmacenUbicacion>()
                        .HasMany(al => al.Articulos)
                        .WithOne(a => a.Ubicacion)
                        .HasForeignKey(al => al.IdUbicacion);

            modelBuilder.Entity<AlmacenUbicacion>()
                        .Property(al => al.Estanteria)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<AlmacenUbicacion>()
                        .Property(al => al.Pasillo)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<AlmacenUbicacion>().HasKey(a => a.Id);


            //Cliente

            modelBuilder.Entity<Cliente>().ToTable("clientes");

            modelBuilder.Entity<Cliente>()
                        .Property(c => c.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>()
                        .HasMany(c => c.Ventas)
                        .WithOne(v => v.Cliente)
                        .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<Cliente>()
                        .Property(c => c.Nombre)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Cliente>()
                        .Property(c => c.Direccion)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Cliente>()
                        .Property(c => c.Email)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Cliente>()
                        .Property(c => c.Poblacion)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);


            //Producto

            modelBuilder.Entity<Producto>().ToTable("productos");

            modelBuilder.Entity<Producto>()
                        .Property(c => c.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Producto>()
                        .HasMany(p =>  p.Articulos)
                        .WithOne(a => a.Producto)
                        .HasForeignKey(a => a.IdProducto);

            modelBuilder.Entity<Producto>()
                        .Property(c => c.Nombre)
                        .HasColumnType("TINYTEXT");

            modelBuilder.Entity<Producto>()
                        .Property(c => c.Codigo)
                        .HasMaxLength(15);

            modelBuilder.Entity<Producto>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Producto>()
                        .HasIndex(p => p.Codigo)
                        .IsUnique();
    


            //Venta

            modelBuilder.Entity<Venta>().ToTable("ventas");

            modelBuilder.Entity<Venta>()
                        .Property(v => v.Id)
                        .IsRequired()
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Venta>().HasKey(c => c.Id);


            modelBuilder.Entity<Venta>()
                        .HasOne(v => v.Articulo)
                        .WithOne(a => a.Venta)
                        .HasForeignKey<Venta>(v => v.NumSerieArticulo)
                        .IsRequired(true);

            modelBuilder.Entity<Venta>()
                        .HasOne(v => v.Cliente)
                        .WithMany(c => c.Ventas)
                        .HasForeignKey(v => v.IdCliente);


        }


    }


}

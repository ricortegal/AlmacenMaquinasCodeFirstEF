using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;

using TPSoluciones.AlmacenMaquinas.Ef.Contexto;
using TPSoluciones.AlmacenMaquinas.Ef.Entidades;

using Xunit;

namespace TPSoluciones.AlmacenMaquinas.Ef.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void EnsureCreated()
        {
            var context = new AlmacenMaquinasDbContext();
            context.Database.EnsureCreated();
        }


        [Fact]
        public void CrearUnProducto()
        {
            var context = new AlmacenMaquinasDbContext();
            context.Database.EnsureCreated();

            context.Productos.Add(new Producto()
            {
                Nombre = "Lavadora Automática Z111",
                Codigo = "Z111",
                Descripcion = "Super lavadora modbus para lavados prepagos",
                Articulos = new List<Articulo>() {
                    new Articulo
                    {
                       NumSerie = "AFSADFA1242343"
                    },
                    new Articulo
                    {
                       NumSerie = "ASD32423444444"
                    }
                }

            });

            context.SaveChanges();
            var productos = context.Productos.Include(p => p.Articulos);
            Assert.True(productos.Any());
            context.Productos.RemoveRange(productos);
            context.SaveChanges();
            Assert.False(productos.Any());
        }


        [Fact]
        public void MigrarBaseDatos()
        {
            var context = new AlmacenMaquinasDbContext();
            context.Database.Migrate();
        }
    }
}
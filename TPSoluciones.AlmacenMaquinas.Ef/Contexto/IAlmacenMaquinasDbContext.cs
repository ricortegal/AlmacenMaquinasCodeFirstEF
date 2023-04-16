using Microsoft.EntityFrameworkCore;

using TPSoluciones.AlmacenMaquinas.Ef.Entidades;

namespace TPSoluciones.AlmacenMaquinas.Ef.Contexto
{
    public interface IAlmacenMaquinasDbContext
    {
        DbSet<Articulo> Articulos { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<AlmacenUbicacion> Ubicaciones { get; set; }
        DbSet<Venta> Ventas { get; set; }
    }
}
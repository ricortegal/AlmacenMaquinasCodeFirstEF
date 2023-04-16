using System;

namespace TPSoluciones.AlmacenMaquinas.Ef.Entidades
{
    public class Venta
    {

        public Venta()
        {
            Id = 0;
            Fecha = new DateTime(1990, 1, 1);
            IdCliente = 0;
            NumSerieArticulo = string.Empty;
            Precio = 0;
            Articulo = null;
            Cliente = null;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Precio { get; set; }
        public string NumSerieArticulo { get; set; }
        public Articulo? Articulo { get; set; }
        public Cliente? Cliente { get; set; }
    }
}

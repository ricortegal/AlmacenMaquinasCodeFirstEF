using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSoluciones.AlmacenMaquinas.Ef.Entidades
{
    public class Articulo
    {

        public Articulo() 
        {
            NumSerie = string.Empty;
            IdProducto = 0;
            Producto = null;
            Ubicacion = null;
            NotasFabricacion = string.Empty;
            NotasRecepcion = string.Empty;
            NotasInstalacion = string.Empty;
            FechaFabricacion = new DateTime(1990, 1, 1);
            FechaRecepcion = new DateTime(1990, 1, 1);
            FechaInstalacion = null;
            Venta = null;
        }

        public string NumSerie { get; set; }
        public string NotasFabricacion { get; set; }
        public string NotasRecepcion { get; set; }
        public string NotasInstalacion { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime? FechaInstalacion { get; set; }
        public int IdProducto { get; set; }
        public Producto? Producto { get; set; }
        public int IdUbicacion { get; set; }
        public Venta? Venta { get; set; }
        public AlmacenUbicacion? Ubicacion { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSoluciones.AlmacenMaquinas.Ef.Entidades
{
    public class Producto
    {

        public Producto() 
        {
            Id = 0;
            Codigo = string.Empty;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            FechaAlta = new DateTime(1990,1,1);
            Articulos = new List<Articulo>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }

        public List<Articulo> Articulos { get; set;}
        
    }
}

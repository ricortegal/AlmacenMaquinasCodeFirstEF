using System.Collections.Generic;

namespace TPSoluciones.AlmacenMaquinas.Ef.Entidades
{
    public class Cliente
    {

        public Cliente() 
        {
            Id = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Cp = 0;
            Poblacion = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Cp { get; set; }
        public string Poblacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public List<Venta> Ventas = new List<Venta>();


    }
}
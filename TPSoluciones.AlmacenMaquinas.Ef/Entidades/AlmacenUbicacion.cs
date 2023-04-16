using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSoluciones.AlmacenMaquinas.Ef.Entidades
{
    public class AlmacenUbicacion
    {

        public AlmacenUbicacion() 
        {
            Id = 0;
            Pasillo = string.Empty;
            Estanteria = string.Empty;
            Altura = 0;
            Posicion = 0;
            Articulos = new List<Articulo>();
        }

        public int Id { get; set; }
        public string Pasillo { get; set; }
        public string Estanteria { get; set; }
        public int Altura { get; set; }
        public int Posicion { get; set; }
        public List<Articulo> Articulos { get; set; }

    }
}

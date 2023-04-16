namespace Nomem.App
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json.Linq;

    using TPSoluciones.AlmacenMaquinas.Ef.Contexto;

    class Program
    {
        static void Main(string[] args)
        {
            //Precarga Base Datos

            var dbContext = new AlmacenMaquinasDbContext();
            dbContext.Database.Migrate();

            var cargaBaseDatos = new CargaBaseDatos(dbContext);

            //cargaBaseDatos.CargaClientes();
            //cargaBaseDatos.CargaProductos();
            //cargaBaseDatos.CreaUbicacionesAlmacen();
            //cargaBaseDatos.EntradaDeArticulos();
            cargaBaseDatos.GeneraVentas();

        }
    }

}
using GeneradorRegistros;

using TPSoluciones.AlmacenMaquinas.Ef.Contexto;
using TPSoluciones.AlmacenMaquinas.Ef.Entidades;

namespace Nomem.App
{
    public class CargaBaseDatos
    {
        private readonly AlmacenMaquinasDbContext _db;
        private readonly GeneradorNombresDirecciones _generadorNombres;
        private readonly Random _random;

        public CargaBaseDatos(AlmacenMaquinasDbContext db)
        {
            _db = db;
            _generadorNombres = new GeneradorNombresDirecciones();
            _random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
        }


        public void CargaClientes(int n=1000)
        {
            for(int i = 0; i < n; i++)
            {
                var cliente = new Cliente();

                cliente.Nombre = _generadorNombres.GetNombreYDosApellidos();
                cliente.Direccion = _generadorNombres.GetDireccionSinVia();
                cliente.Cp = Convert.ToInt32(_generadorNombres.GetCp());
                int codProvincia = cliente.Cp / 1000;
                cliente.Poblacion = _generadorNombres.GetNombreProvincia(codProvincia);
                _db.Clientes.Add(cliente);
            }
            _db.SaveChanges();
        }


        public void CargaProductos()
        {
            _db.Productos.Add(new Producto()
            {
                Codigo = "XC2323",
                Nombre = "Máquina de Vending AutoPosit XC",
                Descripcion = "Central de máquinas de vending conectado a la nube",
                FechaAlta = DateTime.Now.AddDays(-43)
            }); 

            _db.Productos.Add(new Producto()
            {
                Codigo = "MD9212",
                Nombre = "Servidor MD Ultra 1000Tb",
                Descripcion = "Super servidor para nube personal",
                FechaAlta = DateTime.Now.AddDays(-101)
            });

            _db.Productos.Add(new Producto()
            {
                Codigo = "BF1288",
                Nombre = "Central de Conexión Cámaras",
                Descripcion = "Central de Conexión Cámaras para sistema Vigilancia",
                FechaAlta = DateTime.Now.AddDays(-23)
            });

            _db.Productos.Add(new Producto()
            {
                Codigo = "CC4451",
                Nombre = "Sistema Domótico Avanzado",
                Descripcion = "Centro domótico para grandes edificios",
                FechaAlta = DateTime.Now.AddDays(-87)
            });

            _db.Productos.Add(new Producto()
            {
                Codigo = "NN9451",
                Nombre = "Pantalla Gigante 120\"",
                Descripcion = "Super pantalla gigante",
                FechaAlta = DateTime.Now.AddDays(-11)
            });

            _db.Productos.Add(new Producto()
            {
                Codigo = "GH1002",
                Nombre = "Centro de Fichaje GH1000",
                Descripcion = "Centro de fichaje",
                FechaAlta = DateTime.Now.AddDays(-11)
            });
        }



        public void CreaUbicacionesAlmacen()
        {
            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 1,
                Estanteria = "E2",
                Pasillo = "Principal",
                Posicion = 1
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 2,
                Estanteria = "E2",
                Pasillo = "Principal",
                Posicion = 1
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 2,
                Estanteria = "E2",
                Pasillo = "Principal",
                Posicion = 3
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 2,
                Estanteria = "E2",
                Pasillo = "Principal",
                Posicion = 2
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 1,
                Estanteria = "B2",
                Pasillo = "Principal",
                Posicion = 4
            });


            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 1,
                Estanteria = "C2",
                Pasillo = "Lateral",
                Posicion = 11
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 2,
                Estanteria = "E5",
                Pasillo = "Principal",
                Posicion = 7
            });

            _db.Ubicaciones.Add(new AlmacenUbicacion()
            {
                Altura = 3,
                Estanteria = "A5",
                Pasillo = "Secundario",
                Posicion = 9
            });

            _db.SaveChanges();
                
        }


        public void EntradaDeArticulos(int num = 1000)
        {
            var productos = _db.Productos.ToList();
            var ubicaciones = _db.Ubicaciones.ToList();

            var random = new Random(DateTime.Now.Millisecond);

            for (int i=0; i<num; i++)
            {
                var articulo = new Articulo()
                {
                    FechaFabricacion = DateTime.Now.AddDays((-1) * random.Next(20,1000)),
                    NotasFabricacion = "",
                    NotasRecepcion = "",
                    NumSerie = GeneraNumSerie()
                };
                articulo.FechaRecepcion = articulo.FechaFabricacion.AddDays(10);
                articulo.IdProducto = productos[_random.Next(0, productos.Count() - 1)].Id;
                articulo.IdUbicacion = ubicaciones[_random.Next(0, ubicaciones.Count() - 1)].Id;
                _db.Articulos.Add(articulo);
            }

            _db.SaveChanges();
           
        }


        public void GeneraVentas(int num = 1000)
        {
            var numArticulos = _db.Articulos.Where(a => a.FechaInstalacion == null).Count();
            var numClientes = _db.Clientes.Count();

            if (numArticulos < num)
            {
                num = numArticulos; 
            }

            for(int i=0; i<num; i++) 
            {
                var cliente = _db.Clientes.Skip(_random.Next(0, numClientes - 1)).FirstOrDefault();
                var articulo = _db.Articulos.Skip(i).FirstOrDefault();
                if(articulo != null && cliente !=null)
                {
                    articulo.FechaInstalacion = articulo.FechaRecepcion.AddDays(_random.Next(2,45));

                    var venta = new Venta()
                    {
                        NumSerieArticulo = articulo.NumSerie,
                        IdCliente = cliente.Id,
                        Fecha = articulo.FechaInstalacion.Value.AddDays(-1),
                        Precio = _random.Next(400000, 500000)
                    };
                    _db.Ventas.Add(venta);
                }
            }
            _db.SaveChanges();
        }



        private string GeneraNumSerie()
        {
            char[] salida = new char[15];

            int iLetra = 0;
            int iNumero = 0;

   
            var letras = "ABCDEFGHIJKLMNOPQRTS";
            var numeros = "0123456789";
            for(int l=0; l<6; l++)
            {
                for (int i = 0; i < letras.Length; i++)
                {
                    iLetra = _random.Next(0,letras.Length - 1);
                    salida[l] = letras[iLetra];
                }
            }
            for (int l = 6; l < 15; l++)
            {
                for (int i = 0; i < numeros.Length; i++)
                {
                    iNumero = _random.Next(0,numeros.Length - 1);
                    salida[l] = numeros[iNumero];
                }
            }

            return new string(salida);

        }

    }
}



namespace GeneradorRegistros
{
    public class GeneradorNombresDirecciones
    {

        private readonly Random _random;

        public GeneradorNombresDirecciones()
        {
            _random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
        }


        public string GetNombreYDosApellidos()
        {
            int indiceNombre = _random.Next(0,Colecciones.Nombres.Count-1);
            int indiceApellido1 = _random.Next(0, Colecciones.Apellidos.Count - 1);
            int indiceApellido2 = _random.Next(0, Colecciones.Apellidos.Count - 1);
            return $"{Colecciones.Nombres[indiceNombre]} {Colecciones.Apellidos[indiceApellido1]} {Colecciones.Apellidos[indiceApellido2]}";
        }


        public string GetDosApellidos()
        {
            int indiceApellido1 = _random.Next(0, Colecciones.Apellidos.Count - 1);
            int indiceApellido2 = _random.Next(0, Colecciones.Apellidos.Count - 1);
            return $"{Colecciones.Apellidos[indiceApellido1]} {Colecciones.Apellidos[indiceApellido2]}";
        }

        public string GetNombre()
        {
            int indiceNombre = _random.Next(0, Colecciones.Nombres.Count - 1);
            return $"{Colecciones.Nombres[indiceNombre]}";
        }


        public string GetDireccionSinVia()
        {
            int  i = _random.Next(0, Colecciones.ViasNombre.Count - 1);
            int numero = _random.Next(0, 140);
            return $"{Colecciones.ViasNombre[i]}, Nº {numero}";
        }


        public string GetCp()
        {
            int cpProvincia = _random.Next(1, 52);
            int cpNunicipio = _random.Next(1, 999);
            return $"{cpProvincia:00}{cpNunicipio:000}";
        }


        public string GetNombreProvincia(string cp2Provincia)
        {
            var provincia = Colecciones.ProvinciasCp.FirstOrDefault(p => p.Codigo == cp2Provincia);
            if (provincia == null)
            {
                return "DESCONOCIDA";
            }

            return provincia.Nombre;
        }


        public string GetNombreProvincia(int numProvincia)
        {
            var cp = $"{numProvincia:00}";
            var provincia = Colecciones.ProvinciasCp.FirstOrDefault(p => p.Codigo == cp);
            if (provincia == null)
            {
                return "DESCONOCIDA";
            }

            return provincia.Nombre;
        }


    }
}

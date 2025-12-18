using EspacioCadete;
using EspacioCadeteria;
using EspacioPedidos;

namespace EspacioArchivos
{
    public static class Archivos
    {
        public static string[] LeerArchivo(string ruta)
        {
            // verificamos si el archivo existe //
            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);
                return lineas;
            }
            return null;
        }

        // metodos para cargar la cadeteria //
        public static Cadeteria ConvertirCadeteria(string[] lineas, List<Cadete> listadoCadetes)
        {
            Cadeteria cadeteria = null;
            bool primeraFilaBienCargada = false;
            for(int i = 0; i < lineas.Length; i++)
            {
                string FilaActual = lineas[i];
                string[] ColumnasFilaActual = FilaActual.Split([',']);

                if(i == 0)
                {
                    primeraFilaBienCargada = VerificarPrimeraFila(["nombre","telefono"],ColumnasFilaActual);
                    if (!primeraFilaBienCargada)
                    {
                        return null;
                    }
                }

                else
                {
                    // creamos la cadeteria y lo agregamos a la lista //
                    cadeteria = new Cadeteria(ColumnasFilaActual[0],ColumnasFilaActual[1],listadoCadetes);
                }
            }
            return cadeteria;
        }
        // metodos para cargar la lista de cadetes //
        public static bool VerificarIgualdadInsensitiva(string[] deberiaSer, string[] columnasFilaActual)
        {
            bool iguales = true;
            for(int i = 0; i < deberiaSer.Length; i++)
            {
                if (!string.Equals(deberiaSer[i], columnasFilaActual[i], StringComparison.OrdinalIgnoreCase))
                {
                    iguales = false;
                }
            }
            return iguales;
        }
        public static bool VerificarPrimeraFila(string[] deberiaSer,string[] columnasFilaActual)
        {
            bool iguales = VerificarIgualdadInsensitiva(deberiaSer,columnasFilaActual);
            return iguales;
        }
        public static List<Cadete> ConvertirListaCadetes(string[] lineas)
        {
            // listado de cadetes //
            List<Cadete> listadoCadetes = new List<Cadete>();

            // variable para ver que la primera fila este bien cargada //
            bool primeraFilaBienCargada = false;
            for(int i = 0; i < lineas.Length; i++)
            {
                string FilaActual = lineas[i];
                string[] columnasDeFilaActual = FilaActual.Split([',']);

                if(i == 0)
                {
                    primeraFilaBienCargada = VerificarPrimeraFila(["id","nombre","direccion","telefono"],columnasDeFilaActual);
                    if (!primeraFilaBienCargada)
                    {
                        return null;
                    }
                }

                else
                {
                    // creamos el cadete y lo agregamos a la lista //
                    Cadete cadete = new Cadete(columnasDeFilaActual[0],columnasDeFilaActual[1],columnasDeFilaActual[2],columnasDeFilaActual[3]);
                    listadoCadetes.Add(cadete);
                }

            }
            return listadoCadetes;
        
        }

        
    }
}
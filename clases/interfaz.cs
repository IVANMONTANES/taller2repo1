using EspacioArchivos;
using EspacioCadete;
using EspacioCadeteria;

namespace EspacioInterfaz
{
    public static class Interfaz{
        public static void LeerArchivosCsv(ref List<Cadete> listadoCadetes, ref Cadeteria cadeteria)
        {
            // rutas de los archivos //
            string rutaArchivoCadetes = "archivos/cadetes.csv";
            string rutaArchivoCadeteria = "archivos/cadeteria.csv";
            
            // obtenemos el contenido de los archivos //
            string[] retornoArchivoCadetes = Archivos.LeerArchivo(rutaArchivoCadetes);
            string[] retornoArchivosCadeteria = Archivos.LeerArchivo(rutaArchivoCadeteria);

            // tratamos de convertir el contenido a objetos //
            listadoCadetes = Archivos.ConvertirListaCadetes(retornoArchivoCadetes);
            cadeteria = Archivos.ConvertirCadeteria(retornoArchivosCadeteria);
        }

        public static bool VerificarCargaCsv(List<Cadete> listadoCadetes,Cadeteria cadeteria)
        {
            if(listadoCadetes != null && cadeteria != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Menu()
        {
            // variables para la cadeteria y el listado de cadetes //
            List<Cadete> listadoCadetes = new List<Cadete>();
            Cadeteria cadeteria = null;

            // llamamos a la funcion que trata de asignarle a cada variable su valor //
            LeerArchivosCsv(ref listadoCadetes,ref cadeteria);

            // verificamos que se hayan cargado con exito ambas variables //
            bool cargadasConExito = VerificarCargaCsv(listadoCadetes,cadeteria);
            if (cargadasConExito)
            {
                Console.WriteLine("se cargaron con exito");
            }
            else
            {
                Console.WriteLine("algo fallo");
            }
        }
    }
    
}
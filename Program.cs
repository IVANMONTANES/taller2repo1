using EspacioArchivos;
using EspacioCadete;
using EspacioCadeteria;
using EspacioUI;
// variables para la cadeteria y el listado de cadetes //
List<Cadete> listadoCadetes = new List<Cadete>();
Cadeteria cadeteria = null;

// llamamos a la funcion que trata de asignarle a cada variable su valor //
Archivos.LeerArchivosCsv(ref listadoCadetes,ref cadeteria);

// verificamos que se hayan cargado con exito ambas variables //
bool cargadasConExito = Archivos.VerificarCargaCsv(listadoCadetes,cadeteria);

if (cargadasConExito)
{
    // variable para la opcion elegida //
    int opcion = default;
                
    // bucle con las opciones //
    bool seguir = true;

    while (seguir)
    {
        opcion = Ui.PedirOpcionValida();
        Ui.EjecutarOperacion(cadeteria,opcion,ref seguir);
    }
}
else
{
    Console.WriteLine("algo fallo");
}
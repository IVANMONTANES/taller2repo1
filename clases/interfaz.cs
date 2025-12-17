using EspacioArchivos;
using EspacioCadete;
using EspacioCadeteria;
using EspacioPedidos;

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

            // asignamos el listado de cadetes a la cadeteria //
            cadeteria.ListadoCadetes = listadoCadetes;
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

        public static void Opciones(ref int elegida)
        {
                Console.WriteLine("========== SISTEMA CADETERIA ===========");
                Console.WriteLine("1: Dar de alta pedidos");
                Console.WriteLine("2: Asignar pedido a cadete");
                Console.WriteLine("3: Cambiar Estado De Pedido");
                Console.WriteLine("4: Reasignar Pedido");
                Console.WriteLine("5: Finalizar Jornada");
                Console.WriteLine("Ingrese una opcion");
                string elegidaCadena = Console.ReadLine();
                int.TryParse(elegidaCadena,out elegida);
        }

        public static bool VerificarOpcionValida(int elegida)
        {
            if(elegida >= 1 && elegida <= 5)
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
                // variable para los pedidos pendientes //
                List<Pedido> PedidosPendientes = new List<Pedido>();
                // variable para los numeros de los pedidos //
                int nro = 1;

                // variable para la opcion elegida //
                int elegida = default;
                
                // bucle con las opciones //
                bool seguir = true;
                while (seguir)
                {
                    // metodo con las opciones //
                    Opciones(ref elegida);
                    // metodo para verificar que se haya seleccionado una opcion disponible //
                    if (VerificarOpcionValida(elegida))
                    {
                        // ejecutamos los distintas opciones segun corresponda //
                        switch (elegida)
                        {
                            case 1: 
                                PedidosPendientes.Add(cadeteria.DarDeAltaPedido(ref nro));
                                Console.WriteLine("pedido agregado");
                            break;

                            case 2:
                                cadeteria.AsignarPedido(PedidosPendientes);
                            break;

                            case 5:
                                Console.WriteLine("Jornada finalizada"); 
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Porfavor ingrese una opcion valida");
                    }
                }
                

                // ejecutamos la accion correspondiente //
            }
            else
            {
                Console.WriteLine("algo fallo");
            }
        }
    }
    
}
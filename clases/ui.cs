using EspacioCadete;
using EspacioCadeteria;
using EspacioCliente;
using EspacioPedidos;

namespace EspacioUI
{
    public static class Ui
    {
        // ui para mostrar datos //
        public static void MostrarDatos(Cadeteria cadeteria)
        {
            Console.WriteLine("========== CADETERIA ==========");
            Console.WriteLine($"Nombre: {cadeteria.Nombre}");
            Console.WriteLine($"Telefono: {cadeteria.Telefono}");
        }
        
        public static void MostrarDatos(Cadete cadete)
        {
            Console.WriteLine("=========== CADETE ===========");
            Console.WriteLine($"Id: {cadete.Id}");
            Console.WriteLine($"Nombre: {cadete.Nombre}");
            Console.WriteLine($"Direccion: {cadete.Direccion}");
            Console.WriteLine($"Telefono: {cadete.Telefono}");
        }
        public static void MostrarListadoCadetes(List<Cadete> ListadoCadetes)
        {
            // mostramos el listado de cadetes //
            foreach(Cadete cadete in ListadoCadetes)
            {
                MostrarDatos(cadete);
            }
        }

        // ui para dar de alta un pedido //
        public static Cliente CargarCliente(Cadeteria cadeteria)
        {
            // variables donde se cargaran los datos //
            string NombreCliente = string.Empty;
            string DireccionCliente = string.Empty;
            string TelefonoCliente = string.Empty;
            string DatosReferenciaDireccionCliente = string.Empty;
            // booleanos para verificar que se cargue todo //
            bool nombreClienteCargado = false;
            bool DireccionClienteCargado = false;
            bool TelefonoClienteCargado = false;

            while (!nombreClienteCargado)
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                NombreCliente = Console.ReadLine();
                if (!string.IsNullOrEmpty(NombreCliente))
                {
                    nombreClienteCargado = true;
                }
            }

            while (!DireccionClienteCargado)
            {
                Console.WriteLine("Ingrese la direccion del cliente:");
                DireccionCliente = Console.ReadLine();
                if (!string.IsNullOrEmpty(DireccionCliente))
                {
                    DireccionClienteCargado = true;
                }
            }

            while (!TelefonoClienteCargado)
            {
                Console.WriteLine("Ingrese el telefono del cliente:");
                TelefonoCliente = Console.ReadLine();
                if (!string.IsNullOrEmpty(TelefonoCliente))
                {
                    TelefonoClienteCargado = true;
                }
            }

            Console.WriteLine("Ingrese Datos de referencia de la direccion del cliente:");
            DatosReferenciaDireccionCliente = Console.ReadLine();
            DatosReferenciaDireccionCliente = string.IsNullOrEmpty(DatosReferenciaDireccionCliente) ? "Ningun Dato": DatosReferenciaDireccionCliente;

            // obtenemos el cliente //
            Cliente cliente = cadeteria.CrearCliente(NombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccionCliente);

            return cliente;
        }
        public static Pedido CargarPedido(Cadeteria cadeteria,Cliente cliente)
        {

            Console.WriteLine("ingrese una observacion para el pedido:");
            string obs = Console.ReadLine();
            obs = string.IsNullOrEmpty(obs) ? "ninguna" : obs;

            // creamos el pedido //
            Pedido pedido = cadeteria.CrearPedido(obs,cliente);

            return pedido;
        }

        public static void CartaDarDeAltaPedido()
        {
            Console.WriteLine("pedido agregado con exito");
        }


        // ui para asignar un pedido //

        public static Cadete ObtenerCadete(Cadeteria cadeteria)
        {
            // mostramos el listado de cadetes //
            Ui.MostrarListadoCadetes(cadeteria.ListadoCadetes);
            
            // bucle hasta que se cargue el cadete correctamente //
            bool seguir = true;

            while (seguir)
            {
                // pedimos que se ingrese un id //
                Console.WriteLine("ingrese el id del cadete:");
                string idCadete = Console.ReadLine();

                // verificamos que exista el cadete con ese id //
                Cadete cadete = cadeteria.BuscarCadetePorId(idCadete);

                if(cadete != null)
                {
                    return cadete;
                }
                else
                {
                    Console.WriteLine("No existe Cadete Con ese id");
                }
            }

            return null;
        }

        public static void CartaPedidoAsignado(Cadete cadete, Pedido pedido)
        {
            Console.WriteLine("========== OPERACION REALIZADO CON EXITO ==========");
            Console.WriteLine($"se asigno el pedido Nro {pedido.Nro} al siguiente cadete");
            MostrarDatos(cadete);
        }


        // sobrecargamos el metodo //
        public static Pedido ObtenerPedido(Cadeteria cadeteria)
        {
            bool seguir = true;

            while (seguir)
            {
                // recorremos la lista //
                if(cadeteria.PedidosPendientes.Count == 0)
                {
                    Console.WriteLine("no hay pedidos pendientes para asignar");
                    return null;
                }

                foreach(Pedido pedido in cadeteria.PedidosPendientes)
                {
                    pedido.MostrarPedido();
                }

                // pedimos al usuario que ingrese un numero //
                Console.WriteLine("ingrese el Nro del Pedido:");
                string Nrocadena = Console.ReadLine();
                int Nro;
                int.TryParse(Nrocadena,out Nro);

                // verificamos que exista un pedido con ese numero //
                Pedido pedidoConEseNro = cadeteria.BuscarPedidoPorNro(Nro);

                if(pedidoConEseNro != null)
                {
                    return pedidoConEseNro;
                }
                else
                {
                    Console.WriteLine("No existe pedido con ese Nro");
                }
            }
            return null;
        }

        public static Pedido ObtenerPedido(Cadete cadete)
        {
            bool seguir = true;

            while (seguir)
            {
                // recorremos la lista //
                if(cadete.ListadoPedidos.Count == 0)
                {
                    Console.WriteLine("no se encontraron registros de pedidos para el cadete");
                    return null;
                }

                foreach(Pedido pedido in cadete.ListadoPedidos)
                {
                    pedido.MostrarPedido();
                }

                // pedimos al usuario que ingrese un numero //
                Console.WriteLine("ingrese el Nro del Pedido:");
                string Nrocadena = Console.ReadLine();
                int Nro;
                int.TryParse(Nrocadena,out Nro);

                // verificamos que exista un pedido con ese numero //
                Pedido pedidoConEseNro = cadete.BuscarPedidoPorNro(Nro);

                if(pedidoConEseNro != null)
                {
                    return pedidoConEseNro;
                }
                else
                {
                    Console.WriteLine("No existe pedido con ese Nro");
                }
            }
            return null;
        }

        public static Pedido ObtenerPedido(Cadete cadete, bool estado)
        {
            bool seguir = true;

            while (seguir)
            {
                // recorremos la lista //
                if(cadete.ListadoPedidos.Count == 0)
                {
                    Console.WriteLine("no se encontraron registros de pedidos para el cadete");
                    return null;
                }

                foreach(Pedido pedido in cadete.ListadoPedidos)
                {
                    pedido.MostrarPedido();
                }

                // pedimos al usuario que ingrese un numero //
                Console.WriteLine("ingrese el Nro del Pedido:");
                string Nrocadena = Console.ReadLine();
                int Nro;
                int.TryParse(Nrocadena,out Nro);

                // verificamos que exista un pedido con ese numero //
                Pedido pedidoConEseNro = cadete.BuscarPedidoPorNro(Nro);

                if(pedidoConEseNro != null && pedidoConEseNro.Estado == estado)
                {
                    return pedidoConEseNro;
                }else if(pedidoConEseNro != null && pedidoConEseNro.Estado != estado)
                {
                    Console.WriteLine("no se puede reasignar un pedido ya despachado");
                }
                else
                {
                    Console.WriteLine("No existe pedido con ese Nro");
                }
            }
            return null;
        }

        public static void MostrarCambioDeEstado(Pedido pedido)
        {
            string pedidoActual = pedido.Estado ? "Se cambio el pedido a despachado" : "se cambio el pedido a pendiente";
            Console.WriteLine(pedidoActual);
        }

        public static void IndicarQueSonLosMismos()
        {
            Console.WriteLine("No puede reasignar un pedido al mismo cadete");
        }

        public static void CartaPedidoReasignado(Cadete cadete1, Cadete cadete2, Pedido pedido)
        {
            Console.WriteLine("========== OPERACION REALIZADO CON EXITO ==========");
            Console.WriteLine($"se reasigno el pedido Nro {pedido.Nro} al siguiente cadete");
            MostrarDatos(cadete2);
            Console.WriteLine($"Cadete que lo tenia antes");
            MostrarDatos(cadete1);
        }

        public static int PedirOpcionValida()
        {
            int opcion;
            string entrada;
            do
            {
                Console.WriteLine("========== SISTEMA CADETERIA ===========");
                Console.WriteLine("1: Dar de alta pedidos");
                Console.WriteLine("2: Asignar pedido a cadete");
                Console.WriteLine("3: Cambiar Estado De Pedido");
                Console.WriteLine("4: Reasignar Pedido");
                Console.WriteLine("5: Finalizar Jornada");
                Console.WriteLine("Ingrese una opcion");
                entrada = Console.ReadLine();
            }while(!int.TryParse(entrada,out opcion) || opcion < 1 ||opcion > 5);

            return opcion;
        }

        public static void EjecutarOperacion(Cadeteria cadeteria,int opcion,ref bool Seguir)
        {
            switch (opcion)
            {
                case 1: 
                    cadeteria.DarDeAltaPedido();
                break;

                case 2:
                    cadeteria.AsignarPedido();
                break;

                case 3:
                    cadeteria.CambiarEstadoDePedido();
                break;

                case 4:
                    cadeteria.ReasignarPedido();
                break;

                case 5:
                    Seguir = false;
                break;
            }
        }
        

        
        
    }
}
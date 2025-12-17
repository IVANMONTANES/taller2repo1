using System.Security.Cryptography.X509Certificates;
using EspacioCadete;
using EspacioCliente;
using EspacioPedidos;

namespace EspacioCadeteria
{
    public class Cadeteria{
        private string Nombre;
        private string Telefono;

        public List<Cadete> ListadoCadetes = new List<Cadete>();

        public Cadeteria(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
        // metodos //
        public void MostrarDatos()
        {
            Console.WriteLine("========== CADETERIA ==========");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Telefono: {this.Telefono}");
        }

        private Cliente CrearCliente()
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

            // creamos el cliente //
            Cliente cliente = new Cliente(NombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccionCliente);

            return cliente;
        }

        private Pedido CrearPedido(int nro,Cliente cliente)
        {
            Console.WriteLine("ingrese una observacion para el pedido:");
            string obs = Console.ReadLine();
            obs = string.IsNullOrEmpty(obs) ? "ninguna" : obs;

            // creamos el pedido //
            Pedido pedido = new Pedido(nro,obs,cliente,false);

            return pedido;
        }

        public Pedido DarDeAltaPedido(ref int nro)
        {
            // creamos el cliente //
            Cliente cliente = CrearCliente();

            // creamos el pedido //
            Pedido pedido = CrearPedido(nro,cliente);

            // incrementamos en 1 el nro //
            nro++;

            // devolvemos el pedido //
            return pedido;
        }

        private void MostrarPedido(Pedido pedido)
        {
            Console.WriteLine($"Pedido Nro {pedido.Nro}");
        }

        private Pedido VerificarExistenciaPedido(List<Pedido> PedidosPendientes, int Nro)
        {
            // recorremos la lista de pedidos //
            foreach(Pedido pedido in PedidosPendientes)
            {
                if(pedido.Nro == Nro)
                {
                    return pedido;
                }
            }
            return null;
        }

        private Cadete VerificarExistenciaCadete(List<Cadete> ListadoCadetes, string id)
        {
            // recorremos el listado de cadetes //
            foreach(Cadete cadete in ListadoCadetes)
            {
                if(cadete.Id == id)
                {
                    return cadete;
                }
            }

            return null;
        }

        private Pedido ObtenerPedido(List<Pedido> PedidosPendientes)
        {
            bool seguir = true;

            while (seguir)
            {
                // recorremos la lista //
                foreach(Pedido pedido in PedidosPendientes)
                {
                    MostrarPedido(pedido);
                }

                // pedimos al usuario que ingrese un numero //
                Console.WriteLine("ingrese el Nro del Pedido que desea asignar:");
                string Nrocadena = Console.ReadLine();
                int Nro;
                int.TryParse(Nrocadena,out Nro);

                // verificamos que exista un pedido con ese numero //
                Pedido pedidoConEseNro = VerificarExistenciaPedido(PedidosPendientes,Nro);

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

        private Cadete ObtenerCadete()
        {
            // mostramos el listado de cadetes //
            foreach(Cadete cadete in this.ListadoCadetes)
            {
                cadete.MostrarDatos();
            }
            
            // bucle hasta que se cargue el cadete correctamente //
            bool seguir = true;

            while (seguir)
            {
                // pedimos que se ingrese un id //
                Console.WriteLine("ingrese el id del cadete:");
                string idCadete = Console.ReadLine();

                // verificamos que exista el cadete con ese id //
                Cadete cadete = VerificarExistenciaCadete(this.ListadoCadetes,idCadete);

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

        private void CartaPedidoAsignado(Cadete cadete, Pedido pedido)
        {
            Console.WriteLine("========== OPERACION REALIZADO CON EXITO ==========");
            Console.WriteLine($"se asigno el pedido Nro {pedido.Nro} al siguiente cadete");
            cadete.MostrarDatos();
        }
        
        public void AsignarPedido(List<Pedido> PedidosPendientes)
        {
            if(PedidosPendientes.Count != 0)
            {
                // llamamos al metodo para obtener el pedido //
                Pedido pedidoConEseNro = ObtenerPedido(PedidosPendientes);

                // llamamos al metodo para obtener el cadete //
                Cadete cadete = ObtenerCadete();

                // agregamos el pedido al listado del cadete //
                cadete.ListadoPedidos.Add(pedidoConEseNro);

                // eliminamos el pedido del listado de pendientes //
                PedidosPendientes.Remove(pedidoConEseNro);

                // mostramos el mensaje de exito de la operacion //
                CartaPedidoAsignado(cadete,pedidoConEseNro);

                
            }
            else
            {
                Console.WriteLine("no hay pedidos para asignar");
            }
            
        }
    }
}
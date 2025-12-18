using System.Security.Cryptography.X509Certificates;
using EspacioCadete;
using EspacioCliente;
using EspacioPedidos;
using EspacioUI;

namespace EspacioCadeteria
{
    public class Cadeteria{
        public string Nombre {get;}
        public string Telefono {get;}

        public List<Cadete> ListadoCadetes {get;} = new List<Cadete>();

        public List<Pedido> PedidosPendientes {get;}= new List<Pedido>();

        private int NroPedido = 1;

        public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
        {
            Nombre = nombre;
            Telefono = telefono;
            ListadoCadetes = listadoCadetes;
        }
        // metodos //
        
        public  Cliente CrearCliente(string NombreCliente, string DireccionCliente, string TelefonoCliente, string DatosReferenciaDireccionCliente)
        {
            
            // creamos el cliente //
            Cliente cliente = new Cliente(NombreCliente,DireccionCliente,TelefonoCliente,DatosReferenciaDireccionCliente);

            return cliente;
        }

        public Pedido CrearPedido(string obs,Cliente cliente)
        {
            // creamos el pedido //
            Pedido pedido = new Pedido(NroPedido,obs,cliente,false);
            NroPedido++;
            return pedido;
        }

        public void DarDeAltaPedido()
        {
            // creamos el cliente //
            Cliente cliente = Ui.CargarCliente(this);

            // creamos el pedido //
            Pedido pedido = Ui.CargarPedido(this,cliente);

            // agregamos el pedido //
            PedidosPendientes.Add(pedido);

            Ui.CartaDarDeAltaPedido();
        }

        public Pedido BuscarPedidoPorNro(int Nro)
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

        public Cadete BuscarCadetePorId(string id)
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

        
        public void AsignarPedido()
        {
            // llamamos al metodo para obtener el pedido //
            Pedido pedidoConEseNro = Ui.ObtenerPedido(this);
            if(pedidoConEseNro == null)
            {
                return;
            }

            // llamamos al metodo para obtener el cadete //
            Cadete cadete = Ui.ObtenerCadete(this);

            // agregamos el pedido al listado del cadete //
            cadete.AgregarPedido(pedidoConEseNro);

            // eliminamos el pedido del listado de pendientes //
            PedidosPendientes.Remove(pedidoConEseNro);

            // mostramos el mensaje de exito de la operacion //
            Ui.CartaPedidoAsignado(cadete,pedidoConEseNro);
          
        }
        
        public void CambiarEstadoDePedido()
        {
            // obtenemos el cadete //
            Cadete cadete = Ui.ObtenerCadete(this);

            // obtenemos el pedido //
            Pedido pedidoConEseNro = Ui.ObtenerPedido(cadete);
            if(pedidoConEseNro == null)
            {
                return;
            }

            // cambiamos el estado del pedido //
            pedidoConEseNro.ModificarEstado();

            // mostramos el cambio de estado //
            Ui.MostrarCambioDeEstado(pedidoConEseNro);
            
        }

        public void ReasignarPedido(){
            // obtenemos el cadete1 //
            Cadete cadete1 = Ui.ObtenerCadete(this);

            // obtenemos el pedido //
            Pedido pedidoNoEntregadoConEseNro = Ui.ObtenerPedido(cadete1,false);

            if(pedidoNoEntregadoConEseNro == null)
            {
                return;
            }

            // obtenemos el cadete2 /
            Cadete cadete2 = Ui.ObtenerCadete(this);
            while(cadete1 == cadete2)
            {
                Ui.IndicarQueSonLosMismos();
                cadete2 = Ui.ObtenerCadete(this);
            }

            // agregamos el pedido al cadete 2 y se lo eliminamos al cadete 1 //
            cadete1.EliminarPedido(pedidoNoEntregadoConEseNro);
            cadete2.AgregarPedido(pedidoNoEntregadoConEseNro);

            // mostramos el mensaje de exito en la operacion //
            Ui.CartaPedidoReasignado(cadete1,cadete2,pedidoNoEntregadoConEseNro);
        }

    }
}
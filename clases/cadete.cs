using System.Dynamic;
using EspacioPedidos;

namespace EspacioCadete
{
    public class Cadete
    {
        public string Id {get;}
        public string Nombre {get;}
        public string Direccion {get;}
        public string Telefono {get;}
        public List<Pedido> ListadoPedidos {get;}= new List<Pedido>();

        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        // metodos //
        public int JornalACobrar()
        {
            int monto = 0;
            // recorremos la lista con pedidos //
            foreach(Pedido pedido in ListadoPedidos)
            {
                if (pedido.Estado)
                {
                    monto += 500;
                }
            }

            return monto;
        }


        public void AgregarPedido(Pedido pedido)
        {
            ListadoPedidos.Add(pedido);
        }

        public void EliminarPedido(Pedido pedido)
        {
            ListadoPedidos.Remove(pedido);
        }

        public void MostrarPedidos()
        {
            foreach(Pedido pedido in ListadoPedidos)
            {
                pedido.MostrarPedido();
            }
        }

        public Pedido BuscarPedidoPorNro(int Nro)
        {
            // recorremos la lista de pedidos //
            foreach(Pedido pedido in ListadoPedidos)
            {
                if(pedido.Nro == Nro)
                {
                    return pedido;
                }
            }
            return null;
        }

        
    }
}
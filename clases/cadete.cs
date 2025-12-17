using EspacioPedidos;

namespace EspacioCadete
{
    public class Cadete
    {
        private string Id;
        private string Nombre;
        private string Direccion;
        private string Telefono;
        public List<Pedido> ListadoPedidos = new List<Pedido>();

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

        public void MostrarDatos()
        {
            Console.WriteLine("=========== CADETE ===========");
            Console.WriteLine($"Id: {this.Id}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Direccion: {this.Direccion}");
            Console.WriteLine($"Telefono: {this.Telefono}");
        }
    }
}
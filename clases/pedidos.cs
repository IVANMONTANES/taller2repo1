using EspacioCliente;

namespace EspacioPedidos
{
   public class Pedido
    {
        public int Nro {get;}
        private string Obs {get;}
        private Cliente Cliente;

        public Pedido(int nro, string obs, Cliente cliente, bool estado)
        {
            Nro = nro;
            Obs = obs;
            Cliente = cliente;
            Estado = estado;
        }

        public bool Estado {get; private set;}

        // metodos //

        private void MostrarNombre()
        {
            Console.WriteLine($"========== {this.Cliente.Nombre} ==========");
        }
        public void VerDireccionCliente()
        {
            this.MostrarNombre();
            Console.WriteLine($"Direccion: {this.Cliente.Direccion}");
            Console.WriteLine($"Datos de referencia: {this.Cliente.DatosReferenciaDireccion}");
        }

        public void VerDatosCliente()
        {
            VerDireccionCliente();
            Console.WriteLine($"Telefono: {this.Cliente.Telefono}");
        }

        public void MostrarPedido()
        {
            Console.WriteLine("========== PEDIDO =========");
            Console.WriteLine($"Numero: {Nro}");
            Console.WriteLine($"Obs: {Obs}");
            String estadoString = Estado == true ? "despachado" : "pendiente";
            Console.WriteLine($"Estado: {estadoString}");
        }

        public void ModificarEstado()
        {
            this.Estado = this.Estado == true ? false: true;
        }
    } 
}

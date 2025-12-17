using EspacioCliente;

namespace EspacioPedidos
{
   public class Pedido
    {
        private int Nro {get;}
        private string Obs {get;}
        private Cliente Cliente;
        public bool Estado {get;}

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
    } 
}

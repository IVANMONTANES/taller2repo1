using EspacioCadete;

namespace EspacioCadeteria
{
    public class Cadeteria{
        private string Nombre;
        private string Telefono;
        public List<Cadete> ListadoCadetes {get;}

        // metodos //
        public void MostrarDatos()
        {
            Console.WriteLine("========== CADETERIA ==========");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Telefono: {this.Telefono}");
        }
    }
    

}
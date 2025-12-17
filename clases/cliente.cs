namespace EspacioCliente
{
    public class Cliente{
        public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            DatosReferenciaDireccion = datosReferenciaDireccion;
        }

        public string Nombre {get;}
        public string Direccion {get;}
        public string Telefono {get;}
        public string DatosReferenciaDireccion {get;}
    }

}
## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
- cliente forma parte del pedido, es decir la relacion entre las clases es por composicion
- los pedidos pueden ser reasignados a los cadetes por lo tanto el pedido si puede existir como entidad independiente, por lo tanto hay una relacion por agregacion.
- como en nuestro sistema no interesa lo que pase con los cadetes fuera de la cadeteria, vamos a decir que la relacion entre los cadetes y la cadeteria es por composicion, es decir los cadetes forman parte de la cadeteria

## ● ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
### CLASE CADETERIA
- deberia tener un metodo para mostrar los datos de la cadeteria
- deberia tener un metodo para determinar el total que debe pagar por el despacho de los pedidos
- deberia tener un metodo para reasignar un pedido a otro cadete

### CLASE CADETE
- deberia tener un metodo para listar sus datos
- deberia tener un metodo para saber cuantos pedidos despacho

##  Teniendo en cuenta los principios de abstracción y ocultamiento, que campos, propiedades y métodos deberían ser públicos y cuáles privados.
### CADETERIA
Nombre -> campo privado con un getter pues no queremos modificar el nombre de la cadeteria
Telefono -> campo privado con un getter pues no queremos modificar el telefono de la cadeteria
ListadoCadetes -> campo privado con un getter pues no queremos modificar el listado de cadetes.

### CADETE
Id -> Campo privado pues no queremos modificar el Id del cadete
Nombre -> Campo privado pues no queremos modificar el Nombre del cadete
Direccion -> Campo privado pues no queremos modificar la Direccion del cadete
Telefono -> Campo Privado pues no queremos modificar el Telefono del cadete
ListadoPedidos -> Campo Privado con un getter y un setter definidos pues si nos interesa modificar el lsitado de pedidos
JornalACobrar()-> Metodo Publico pues vamos a necesitar usarlo





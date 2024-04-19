

static void Main(string[] args)
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Producto> productos = new List<Producto>();
        List<Pedido> pedidos = new List<Pedido>();

        // Crear algunos datos de ejemplo
        clientes.Add(new Cliente(1, "Juan Perez", "Calle 123", "123456789", "juan.perez@email.com"));
        productos.Add(new Producto(1, "Camisa", 25.99, "Camisa de algodón talla M"));
        pedidos.Add(new Pedido(1, DateTime.Now, clientes[0], productos, 0));

       
        while (true)
        {
            Console.WriteLine("\nMENÚ PRINCIPAL");
            Console.WriteLine("1. Gestión de clientes");
            Console.WriteLine("2. Gestión de productos");
            Console.WriteLine("3. Gestión de pedidos");
            Console.WriteLine("4. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    GestionClientes(clientes);
                    break;
                case 2:
                    GestionProductos(productos);
                    break;
                case 3:
                    GestionPedidos(pedidos, clientes, productos);
                    break;
                case 4:
                    Console.WriteLine("Saliendo de la aplicación...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void GestionClientes(List<Cliente> clientes)
    {
        while (true)
        {
            Console.WriteLine("\nGESTIÓN DE CLIENTES");
            Console.WriteLine("1. Registrar nuevo cliente");
            Console.WriteLine("2. Modificar cliente existente");
            Console.WriteLine("3. Eliminar cliente");
            Console.WriteLine("4. Ver lista de clientes");
            Console.WriteLine("5. Regresar al menú principal");

            int opcionCliente = int.Parse(Console.ReadLine());

            switch (opcionCliente)
            {
                case 1:
                    Cliente.RegistrarCliente(clientes);
                    break;
                case 2:
                    ModificarCliente(clientes);
                    break;
                case 3:
                    EliminarCliente(clientes);
                    break;
                case 4:
                    VerListaClientes(clientes);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    // Métodos para gestionar productos
    static void GestionProductos(List<Producto> productos)
    {
        while (true)
        {
            Console.WriteLine("\nGESTIÓN DE PRODUCTOS");
            Console.WriteLine("1. Crear nuevo producto");
            Console.WriteLine("2. Modificar producto existente");
            Console.WriteLine("3. Eliminar producto");
            Console.WriteLine("4. Ver lista de productos");
            Console.WriteLine("5. Regresar al menú principal");

            int opcionProducto = int.Parse(Console.ReadLine());

            switch (opcionProducto)
            {
                case 1:
                    Producto.CrearProducto(productos);
                    break;
                case 2:
                    ModificarProducto(productos);
                    break;
                case 3:
                    EliminarProducto(productos);
                    break;
                case 4:
                    VerListaProductos(productos);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    // Métodos para gestionar pedidos
    static void GestionPedidos(List<Pedido> pedidos, List<Cliente> clientes, List<Producto> productos)
    {
        while (true)
        {
            Console.WriteLine("\nGESTIÓN DE PEDIDOS");
            Console.WriteLine("1. Crear nuevo pedido");
            Console.WriteLine("2. Modificar pedido existente");
            Console.WriteLine("3. Cancelar pedido");
            Console.WriteLine("4. Ver lista de pedidos");
            Console.WriteLine("5. Regresar al menú principal");

            int opcionPedido = int.Parse(Console.ReadLine());

        }
    }

// List<Cliente> clientes = new List<Cliente>();
// Cliente nuevoCliente = new Cliente(1, "Juan Perez", "Calle 123", "123456789", "juan.perez@email.com");
// clientes.Add(nuevoCliente);

// List<Producto> productosPedido = new List<Producto>();
// Producto nuevoProducto = new Producto(1, "Teclado Casio", 0, "Teclado de 49 teclas sensibles al tacto");
// productosPedido.Add(nuevoProducto);

// DateTime fechaPedido = DateTime.Now;
// Pedido nuevoPedido = new Pedido(1, fechaPedido, nuevoCliente, productosPedido, 0);


// Console.WriteLine("Registrar nuevo cliente");
// Cliente.RegistrarCliente(clientes);


// Console.WriteLine("Crear nuevo producto");
// Producto.CrearProducto(productosPedido);

// double totalPedido = Pedido.CalcularTotal(productosPedido);
// Console.WriteLine("Total del pedido: {0}", totalPedido);

// productosPedido.Add(nuevoProducto);
// nuevoPedido.Total = Pedido.CalcularTotal(productosPedido);


// int idClienteAModificar = 1;
// Cliente clienteAModificar = clientes.Find(c => c.IdCliente == idClienteAModificar);
// clienteAModificar.Nombre = "Maria Gonzalez";
// clienteAModificar.Direccion = "Calle Nueva 456";


// int idProductoAEliminar = 1;
// Producto productoAEliminar = productosPedido.Find(p => p.IdProducto == idProductoAEliminar);
// productosPedido.Remove(productoAEliminar);
// nuevoPedido.Total = Pedido.CalcularTotal(productosPedido);
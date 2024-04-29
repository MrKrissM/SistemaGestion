﻿


bool exitApp;

do
{
    exitApp = true;
    List<Cliente> clientes = new List<Cliente>();
    List<Producto> productos = new List<Producto>();
    List<Pedido> pedidos = new List<Pedido>();

    Console.WriteLine("\nTIENDA DE PRODUCTOS MUSICALES");
    Console.WriteLine("1. Gestión de clientes");
    Console.WriteLine("2. Gestión de productos");
    Console.WriteLine("3. Gestión de pedidos");
    Console.WriteLine("4. Generar reportes");
    Console.WriteLine("5. Salir");

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
            GenerarReportes(clientes, pedidos, productos);
            break;
        case 5:
            exitApp = false;
            Console.WriteLine("Saliendo de la aplicación...");
            break;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
} while (exitApp);


void GestionClientes(List<Cliente> clientes)
{
    Cliente cliente = new Cliente();
    do
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
                cliente.RegistrarCliente(clientes);
                break;
            case 2:
                Console.Write("ID del cliente a modificar: ");
                int idClienteModificar = int.Parse(Console.ReadLine());
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Nueva dirección: ");
                string nuevaDireccion = Console.ReadLine();
                Console.Write("Nuevo teléfono: ");
                string nuevoTelefono = Console.ReadLine();
                Console.Write("Nuevo correo electrónico: ");
                string nuevoCorreoElectronico = Console.ReadLine();
                cliente.ModificarCliente(cliente.clientesExistentes, idClienteModificar, nuevoNombre, nuevaDireccion, nuevoTelefono, nuevoCorreoElectronico);
                break;
            case 3:
                Console.Write("ID del cliente a eliminar: ");
                int idClienteEliminar = int.Parse(Console.ReadLine());
                cliente.EliminarCliente(cliente.clientesExistentes, idClienteEliminar);
                break;
            case 4:
                cliente.VerListaClientes(cliente.clientesExistentes);
                break;
            case 5:
                return;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                break;
        }
    } while (exitApp);

}

void GestionProductos(List<Producto> productos)
{

    Producto producto = new Producto();
    do
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
                producto.CrearProducto(productos);
                break;
            case 2:
                Console.Write("ID del producto a modificar: ");
                int idProductoModificar = int.Parse(Console.ReadLine());
                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Nuevo precio: ");
                double nuevoPrecio = double.Parse(Console.ReadLine());
                Console.Write("Nueva descripcion: ");
                string nuevaDescripcion = Console.ReadLine();
                producto.ModificarProducto(producto.productosExistentes, idProductoModificar, nuevoNombre, nuevoPrecio, nuevaDescripcion);
                break;
            case 3:
                Console.Write("ID del producto a eliminar: ");
                int idProductoEliminar = int.Parse(Console.ReadLine());
                producto.EliminarProducto(producto.productosExistentes, idProductoEliminar);
                break;
            case 4:
                producto.VerListaProductos(producto.productosExistentes);
                break;
            case 5:
                return;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                break;
        }
    } while (exitApp);
}


void GestionPedidos(List<Pedido> pedidos, List<Cliente> clientes, List<Producto> productos)
{
    Pedido pedido = new Pedido();
    Cliente cliente = new Cliente();
    Producto producto = new Producto();
    do
    {
        Console.WriteLine("\nGESTIÓN DE PEDIDOS");
        Console.WriteLine("1. Crear nuevo pedido");
        Console.WriteLine("2. Modificar pedido existente");
        Console.WriteLine("3. Cancelar pedido");
        Console.WriteLine("4. Ver lista de pedidos");
        Console.WriteLine("5. Regresar al menú principal");

        int opcionPedido = int.Parse(Console.ReadLine());
        switch (opcionPedido)
        {
            case 1:
                pedido.CrearPedido(pedidos, cliente.clientesExistentes, producto.productosExistentes);
                break;
            case 2:
                pedido.ModificarPedido(pedidos, cliente.clientesExistentes, producto.productosExistentes);
                break;
            case 3:
                Console.WriteLine("Ingrese el ID del pedido que desea cancelar: ");
                int idPedidoACancelar = int.Parse(Console.ReadLine());
                pedido.CancelarPedido(pedidos, idPedidoACancelar);
                break;
            case 4:
                pedido.VerListaPedidos(pedidos);
                break;
            case 5:
                return;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                break;
        }

    } while (exitApp);
}

void GenerarReportes(List<Cliente> clientes, List<Pedido> pedidos, List<Producto> productos)
{
    Reportes generadorReportes = new Reportes(clientes, pedidos, productos);

    do
    {
        Console.WriteLine("\nOPCIONES DE REPORTES");
        Console.WriteLine("1. Listado de clientes");
        Console.WriteLine("2. Histórico de pedidos por cliente");
        Console.WriteLine("3. Productos más vendidos");
        Console.WriteLine("4. Regresar al menú principal");

        int opcionReporte = int.Parse(Console.ReadLine());

        switch (opcionReporte)
        {
            case 1:
                generadorReportes.GenerarListaClientes();
                break;
            case 2:
                generadorReportes.GenerarReporteHistoricoPedidos();
                break;
            case 3:
                generadorReportes.GenerarReporteProductosMasVendidos();
                break;
            case 4:
                return;
            default:
                Console.WriteLine("Opción no válida. Intente nuevamente.");
                break;
        }
    } while (exitApp);
}



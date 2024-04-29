public class Pedido
{
    public int IdPedido { get; set; }
    public DateTime FechaPedido { get; set; }
    public Cliente Cliente { get; set; }
    public List<Producto> Productos { get; set; }
    public double Total { get; set; }
    public Data data = new Data();
    public string rutaArchivoPedidos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pedidos.txt");
    public string rutaArchivoClientes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.txt");
    public string rutaArchivoProducto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos.txt");
    private Cliente clienteSeleccionado;
    private List<Producto> productoSeleccionado;

    public List<Pedido> pedidosExistentes { get; set; }
    public List<Cliente> clientesExistentes { get; set; }
    public List<Producto> productosExistentes { get; set; }

    public Pedido(int idPedido, DateTime fechaPedido, Cliente cliente, List<Producto> productos, double total)
    {
        IdPedido = idPedido;
        FechaPedido = fechaPedido;
        Cliente = cliente;
        Productos = productos;
        Total = total;
    }
    public Pedido()
    {
        IdPedido = 0;
        FechaPedido = DateTime.Now;
        clientesExistentes = data.CargarClientes(rutaArchivoClientes);
        productosExistentes = data.CargarProductos(rutaArchivoProducto);
        Productos = new List<Producto>();
        Total = 0;
        pedidosExistentes = data.CargarPedidos(rutaArchivoPedidos);
    }

    public void CrearPedido(List<Pedido> pedidos, List<Cliente> clientesExistentes, List<Producto> productosExistentes)
    {
        try
        {
            // Muestra una lista de clientes al usuario
            Console.WriteLine("\nLista de Clientes:");
            for (int i = 0; i < clientesExistentes.Count; i++)
            {
                Cliente cliente = clientesExistentes[i];
                Console.WriteLine($"{i + 1}. {cliente.Nombre}");
            }
            // Solicita al usuario que seleccione un cliente
            Console.WriteLine("\nSeleccione el número del cliente para el pedido: ");
            int indiceCliente = int.Parse(Console.ReadLine()) - 1;

            if (indiceCliente >= 0 && indiceCliente < clientesExistentes.Count)
            {
                Cliente clienteSeleccionado = clientesExistentes[indiceCliente];
            }
            else
            {
                Console.WriteLine("Índice de cliente inválido. Intente nuevamente.");
            }
            Console.WriteLine("\nLista de Productos:");
            for (int i = 0; i < productosExistentes.Count; i++)
            {
                Producto producto = productosExistentes[i];
                Console.WriteLine($"{i + 1}. {producto.Nombre}");
            }

            Console.WriteLine("\nSeleccione el número de producto para el pedido: ");
            int indiceProducto = int.Parse(Console.ReadLine()) - 1;
            if (indiceProducto >= 0 && indiceProducto < productosExistentes.Count)
            {
                Producto productoSeleccionado = productosExistentes[indiceProducto];
                
            }
            else
            {
                Console.WriteLine("Índice de producto inválido. Intente nuevamente.");
            }
            
            int nuevoIdPedido = pedidosExistentes.Count == 0 ? 1 : pedidosExistentes.Max(p => p.IdPedido) + 1;
            DateTime fechaPedido = DateTime.Now;
            double totalPedido = CalcularTotal(productoSeleccionado);

            Pedido nuevoPedido = new Pedido(nuevoIdPedido, fechaPedido, clienteSeleccionado, productoSeleccionado, totalPedido);
            pedidosExistentes.Add(nuevoPedido);
            pedidos.Clear();
            pedidos.AddRange(pedidosExistentes);
            data.GuardarPedidos(pedidos);
            Console.WriteLine($"\nPedido creado exitosamente para el cliente {clienteSeleccionado.Nombre}.");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear el pedido: " + ex.Message);
        }
    }


    public void ModificarPedido(List<Pedido> pedidos, List<Cliente> clientes, List<Producto> productos)
    {
        try
        {
            // Mostrar lista de pedidos existentes
            Console.WriteLine("\nLista de pedidos existentes:");

            for (int i = 0; i < pedidos.Count; i++)
            {
                Pedido pedido = pedidos[i];
                Console.WriteLine($"{i + 1}. ID: {pedido.IdPedido} - Fecha: {pedido.FechaPedido:dd/MM/yyyy} - Cliente: {pedido.Cliente.Nombre} - Total: {pedido.Total:c2}");
            }
            // Obtener ID del pedido del usuario
            Console.WriteLine("\nIngrese el ID del pedido que desea modificar: ");
            int idPedidoAModificar = int.Parse(Console.ReadLine());

            // Encontrar objeto de pedido
            Pedido pedidoAModificar = pedidos.Find(p => p.IdPedido == idPedidoAModificar);

            // Manejar pedido no encontrado
            if (pedidoAModificar == null)
            {
                Console.WriteLine("No se encontró el pedido con el ID especificado.");
                return;
            }

            // Mostrar productos actuales del pedido
            Console.WriteLine("\nProductos actuales del pedido:");
            foreach (Producto producto in pedidoAModificar.Productos)
            {
                Console.WriteLine($"- {producto.Nombre} ({producto.Precio:c2})");
            }

            // Permitir al usuario modificar los productos
            Console.WriteLine("\nSeleccione los nuevos productos para el pedido (o escriba 'finalizar' para terminar):");
            string opcion;
            List<Producto> nuevosProductos = new List<Producto>();
            do
            {
                Console.WriteLine("\nLista de Productos:");
                for (int i = 0; i < productos.Count; i++)
                {
                    Producto producto = productos[i];
                    Console.WriteLine($"{i + 1}. {producto.Nombre}");
                }
                Console.WriteLine("\nSeleccione el número de producto para agregar al pedido (o escriba 'finalizar' para terminar): ");
                opcion = Console.ReadLine();
                if (opcion.ToLower() != "finalizar")
                {
                    int indiceProducto = int.Parse(opcion) - 1;
                    if (indiceProducto >= 0 && indiceProducto < productos.Count)
                    {
                        Producto productoSeleccionado = productos[indiceProducto];
                        nuevosProductos.Add(productoSeleccionado);
                    }
                    else
                    {
                        Console.WriteLine("Índice de producto inválido. Intente nuevamente.");
                    }
                }
            } while (opcion.ToLower() != "finalizar");

            // Actualizar los productos del pedido
            pedidoAModificar.Productos = nuevosProductos;

            // Recalcular el total del pedido
            pedidoAModificar.Total = CalcularTotal(nuevosProductos);

            // Guardar los cambios en el archivo
            data.GuardarPedidos(pedidos);

            Console.WriteLine("Pedido modificado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al modificar el pedido: " + ex.Message);
        }
    }

    public void CancelarPedido(List<Pedido> pedidos, int idPedido)
    {
        try
        {
            Pedido pedidoACancelar = pedidos.Find(p => p.IdPedido == idPedido);

            if (pedidoACancelar != null)
            {
                pedidos.Remove(pedidoACancelar);
                data.GuardarPedidos(pedidos); // Guardar los cambios en el archivo
                Console.WriteLine("Pedido cancelado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el pedido con el ID especificado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cancelar el pedido: " + ex.Message);
        }
    }
    public double CalcularTotal(List<Producto> productos)
    {

        double total = 0;

        foreach (Producto producto in productos)
        {
            total += producto.Precio;
        }

        return total;
    }

    public void VerListaPedidos(List<Pedido> pedidos)
    {
        try
        {
            if (pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados en el sistema.");
                return;
            }

            Console.WriteLine("\nLISTA DE PEDIDOS");
            Console.WriteLine("-----------------------");
            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine($"\nID: {pedido.IdPedido}");
                Console.WriteLine($"Cliente: {pedido.Cliente.Nombre}");
                Console.WriteLine($"Fecha: {pedido.FechaPedido.ToShortDateString()}");
                Console.WriteLine($"Total: {pedido.Total:C2}");
                Console.WriteLine($"Productos:{pedido.Productos}");
                foreach (Producto producto in pedido.productosExistentes)
                {
                    Console.WriteLine($"  - {producto.Nombre} ({producto.Precio:C2})");
                }
                Console.WriteLine("-----------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ver listado de pedidos: " + ex.Message);
        }

    }
}
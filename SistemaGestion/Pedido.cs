public class Pedido
{
    private int idPedido;
    private DateTime fechaPedido;
    private Cliente cliente;
    private List<Producto> productos;
    private double total;

    public Pedido(int idPedido, DateTime fechaPedido, Cliente cliente, List<Producto> productos, double total)
    {
        this.idPedido = idPedido;
        this.fechaPedido = fechaPedido;
        this.cliente = cliente;
        this.productos = productos;
        this.total = total;
    }

    public int IdPedido { get => idPedido; set => idPedido = value; }
    public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public List<Producto> Productos { get => productos; set => productos = value; }
    public double Total { get => total; set => total = value; }


    public static void CrearPedido(List<Pedido> pedidos, List<Cliente> clientes, List<Producto> productos)
    {
        try
        {
            // Muestra una lista de clientes al usuario
            Console.WriteLine("\nLista de Clientes:");
            for (int i = 0; i < clientes.Count; i++)
            {
                Cliente cliente = clientes[i];
                Console.WriteLine($"{i + 1}. {cliente.Nombre}");
            }
            // Solicita al usuario que seleccione un cliente
            Console.WriteLine("\nSeleccione el número del cliente para el pedido: ");
            int indiceCliente = int.Parse(Console.ReadLine()) - 1;

            if (indiceCliente >= 0 && indiceCliente < clientes.Count)
            {
                Cliente clienteSeleccionado = clientes[indiceCliente];

                int nuevoIdPedido = pedidos.Count == 0 ? 1 : pedidos.Max(p => p.IdPedido) + 1;
                DateTime fechaPedido = DateTime.Now;
                double totalPedido = CalcularTotal(productos);

                Pedido nuevoPedido = new Pedido(nuevoIdPedido, fechaPedido, clienteSeleccionado, productos, totalPedido);
                pedidos.Add(nuevoPedido);

                Console.WriteLine("Pedido creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Índice de cliente inválido. Intente nuevamente.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear el pedido: " + ex.Message);
        }

    }

    public static void ModificarPedido(List<Pedido> pedidos, List<Cliente> clientes, List<Producto> productos)
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

            // Recalcular total
            pedidoAModificar.Total = CalcularTotal(pedidoAModificar.Productos);

            // Mostrar mensaje de éxito
            Console.WriteLine("Pedido modificado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al modificar el pedido: " + ex.Message);
        }
    }

    public static void CancelarPedido(List<Pedido> pedidos, int idPedido)
    {
        try
        {
            Pedido pedidoACancelar = pedidos.Find(p => p.IdPedido == idPedido);

            if (pedidoACancelar != null)
            {
                pedidos.Remove(pedidoACancelar);
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

    public static double CalcularTotal(List<Producto> productos)
    {

        double total = 0;

        foreach (Producto producto in productos)
        {
            total += producto.Precio;
        }

        return total;
    }

    public static void VerListaPedidos(List<Pedido> pedidos)
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
                Console.WriteLine("Productos:");
                foreach (Producto producto in pedido.Productos)
                {
                    Console.WriteLine($"  - {producto.Nombre} ({producto.Precio})");
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
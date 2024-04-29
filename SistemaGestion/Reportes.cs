public class Reportes
{
    private List<Cliente> clientes;
    private List<Pedido> pedidos;
    private List<Producto> productos;
    Cliente cliente = new Cliente();


    public Reportes(List<Cliente> clientes, List<Pedido> pedidos, List<Producto> productos)
    {
        this.clientes = clientes;
        this.pedidos = pedidos;
        this.productos = productos;
    }

    public void GenerarReporteClientes()
    {
        Console.WriteLine("\nListado de clientes registrados:");
        cliente.VerListaClientes(cliente.clientesExistentes);
    }

    public void GenerarReporteHistoricoPedidos()
    {
        Console.WriteLine("\nHistórico de pedidos por cliente:");
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"\nCliente: {cliente.Nombre}");
            List<Pedido> pedidosCliente = pedidos.Where(p => p.Cliente.IdCliente == cliente.IdCliente).ToList();
            if (pedidosCliente.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados para este cliente.");
            }
            else
            {
                foreach (Pedido pedido in pedidosCliente)
                {
                    Console.WriteLine($"Pedido ID: {pedido.IdPedido}, Fecha: {pedido.FechaPedido:dd/MM/yyyy}, Total: {pedido.Total:C2}");
                    Console.WriteLine("Productos:");
                    foreach (Producto producto in pedido.Productos)
                    {
                        Console.WriteLine($"- {producto.Nombre} ({producto.Precio:C2})");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    public void GenerarReporteProductosMasVendidos()
    {
        Console.WriteLine("\nProductos más vendidos:");
        var productosCantidades = productos.SelectMany(p => pedidos.SelectMany(pedido => pedido.Productos.Where(prod => prod.IdProducto == p.IdProducto).Select(prod => (Producto: p, Cantidad: 1)))).GroupBy(pc => pc.Producto).Select(g => new { Producto = g.Key, Cantidad = g.Sum(pc => pc.Cantidad) }).OrderByDescending(pc => pc.Cantidad);

        foreach (var productoContado in productosCantidades)
        {
            Console.WriteLine($"{productoContado.Producto.Nombre} - Cantidad vendida: {productoContado.Cantidad}");
        }
    }
}
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


    public Pedido CrearPedido(List<Pedido> pedidos, Cliente cliente, List<Producto> productos)
    {
        int nuevoIdPedido = pedidos.Count == 0 ? 1 : pedidos.Max(p => p.IdPedido) + 1;
        DateTime fechaPedido = DateTime.Now;
        double totalPedido = CalcularTotal(productos);

        Pedido nuevoPedido = new Pedido(nuevoIdPedido, fechaPedido, cliente, productos, totalPedido);
        pedidos.Add(nuevoPedido);

        Console.WriteLine("Pedido creado exitosamente.");
        return nuevoPedido;
    }

    public void ModificarPedido(List<Pedido> pedidos, int idPedido, Cliente nuevoCliente, List<Producto> nuevosProductos)
    {
        Pedido pedidoAModificar = pedidos.Find(p => p.IdPedido == idPedido);

        if (pedidoAModificar != null)
        {
            pedidoAModificar.Cliente = nuevoCliente;
            pedidoAModificar.Productos = nuevosProductos;
            pedidoAModificar.Total = CalcularTotal(nuevosProductos);

            Console.WriteLine("Pedido modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el pedido con el ID especificado.");
        }
    }

    public void CancelarPedido(List<Pedido> pedidos, int idPedido)
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

    public static double CalcularTotal(List<Producto> productos)
    {
        double total = 0;

        foreach (Producto producto in productos)
        {
            total += producto.Precio;
        }

        return total;
    }

}
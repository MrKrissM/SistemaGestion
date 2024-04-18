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

    // Agregar métodos para crear, modificar y cancelar pedidos
    // Método para calcular el total del pedido
}
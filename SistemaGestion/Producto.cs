public class Producto
{
    private int idProducto;
    private string nombre;
    private double precio;
    private string descripcion;

    public Producto(int idProducto, string nombre, double precio, string descripcion)
    {
        this.idProducto = idProducto;
        this.nombre = nombre;
        this.precio = precio;
        this.descripcion = descripcion;
    }

    public int IdProducto { get => idProducto; set => idProducto = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public double Precio { get => precio; set => precio = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }


    public static void CrearProducto(List<Producto> productos)
    {
        Console.WriteLine("Creación de nuevo producto");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine());
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();

        Producto nuevoProducto = new Producto(productos.Count + 1, nombre, precio, descripcion);
        productos.Add(nuevoProducto);
        Console.WriteLine("Producto creado exitosamente.");
    }

}
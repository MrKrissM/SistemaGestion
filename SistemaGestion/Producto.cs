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
        try
        {
            Console.WriteLine("Creación de nuevo producto");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();
            string rutaProductos = "productos.txt";

            Producto nuevoProducto = new Producto(productos.Count + 1, nombre, precio, descripcion);
            productos.Add(nuevoProducto);
            Data.GuardarProductos(productos, rutaProductos);

            Console.WriteLine("Producto creado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear un nuevo producto: " + ex.Message);
        }
    }

    public static void ModificarProducto(List<Producto> productos, int idProducto, string nuevoNombre, double nuevoPrecio, string nuevaDescripcion)
    {

        try
        {
            Producto productoAModificar = productos.Find(p => p.IdProducto == idProducto);

            if (productoAModificar != null)
            {
                productoAModificar.Nombre = nuevoNombre;
                productoAModificar.Precio = nuevoPrecio;
                productoAModificar.Descripcion = nuevaDescripcion;

                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el producto con el ID especificado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al modificar un producto: " + ex.Message);
        }
    }

    public static void EliminarProducto(List<Producto> productos, int idProducto)
    {
        try
        {
            Producto productoAEliminar = productos.Find(p => p.IdProducto == idProducto);

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el producto con el ID especificado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar un producto: " + ex.Message);
        }
    }
 public static void VerListaProductos(List<Producto> productos)
    {

        try
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
            }
            else
            {
                Console.WriteLine("\nLISTADO DE PRODUCTOS");
                Console.WriteLine("------------------------");
                foreach (Producto producto in productos)
                {
                    Console.WriteLine($"ID: {producto.IdProducto}");
                    Console.WriteLine($"Nombre: {producto.Nombre}");
                    Console.WriteLine($"Precio: {producto.Precio}");
                    Console.WriteLine($"Descripcion: {producto.Descripcion}");
                    Console.WriteLine("------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ver el listado de productos: " + ex.Message);
        }
    }
}
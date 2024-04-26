public class Producto
{
    
    public int IdProducto { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public string Descripcion { get; set; }
    public Data data;
    public string rutaArchivoProductos;
    public List<Producto> productosExistentes;

    public Producto(int idProducto, string nombre, double precio, string descripcion)
    {
        IdProducto = idProducto;
        Nombre = nombre;
        Precio = precio;
        Descripcion = descripcion;

        data = new Data();
        rutaArchivoProductos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos.txt");
        productosExistentes = data.CargarProductos(rutaArchivoProductos);
    }


    public void CrearProducto(List<Producto> productos)
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

            int ultimoIdProducto = productosExistentes.Count > 0 ? productosExistentes.Max(c => c.IdProducto) : 0;
            int nuevoIdProducto = ultimoIdProducto + 1;
            Producto nuevoProducto = new Producto(nuevoIdProducto, nombre, precio, descripcion);

            productosExistentes.Add(nuevoProducto);
            productos.Clear();
            productos.AddRange(productosExistentes);
            
            data.GuardarProductos(productos);

            Console.WriteLine("Producto creado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al crear un nuevo producto: " + ex.Message);
        }
    }

    public void ModificarProducto(List<Producto> productosExistentes, int idProducto, string nuevoNombre, double nuevoPrecio, string nuevaDescripcion)
    {
        try
        {
            Producto productoAModificar = productosExistentes.Find(p => p.IdProducto == idProducto);

            if (productoAModificar != null)
            {
                productoAModificar.Nombre = nuevoNombre;
                productoAModificar.Precio = nuevoPrecio;
                productoAModificar.Descripcion = nuevaDescripcion;

                data.GuardarProductos(productosExistentes);


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

    public void EliminarProducto(List<Producto> productos, int idProducto)
    {
        try
        {
            Producto productoAEliminar = productosExistentes.Find(p => p.IdProducto == idProducto);

            if (productoAEliminar != null)
            {
                productos.Remove(productoAEliminar);
                Console.WriteLine("Producto eliminado exitosamente.");

                data.GuardarProductos(productosExistentes);

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
 public void VerListaProductos(List<Producto> productos)
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
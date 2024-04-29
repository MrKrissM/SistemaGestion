
public class Data
{
  
    public void GuardarClientes(List<Cliente> clientes)
    {
        string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.txt");
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < clientes.Count; i++)
                {
                    Cliente cliente = clientes[i];
                    string linea = $"{cliente.IdCliente},{cliente.Nombre},{cliente.Direccion},{cliente.Telefono},{cliente.CorreoElectronico}";
                    escritor.WriteLine(linea);
                }
            }

            Console.WriteLine("Clientes guardados correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar clientes: " + ex.Message);
        }
    }
    string rutaArchivoProducto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos.txt");
    public void GuardarProductos(List<Producto> productos)
    {
        
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivoProducto))
            {
                for (int i = 0; i < productos.Count; i++)
                {
                    Producto producto = productos[i];
                    string linea = $"{producto.IdProducto},{producto.Nombre},{producto.Precio},{producto.Descripcion}";
                    escritor.WriteLine(linea);
                }
            }
            Console.WriteLine("Productos guardados correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar productos: " + ex.Message);
        }
    }


    public void GuardarPedidos(List<Pedido> pedidos)
    {
        string rutaArchivoPedido = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pedidos.txt");
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaArchivoPedido))
            {
                for (int i = 0; i < pedidos.Count; i++)
                {
                    Pedido pedido = pedidos[i];
                    string productosStr = String.Join(",", pedido.Productos.Select(p => p.Nombre));
                    string linea = $"{pedido.IdPedido},{pedido.Cliente.Nombre},{productosStr},{pedido.FechaPedido},{pedido.Total}";
                    escritor.WriteLine(linea);
                }
            }
            Console.WriteLine("Pedidos guardados correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar pedidos: " + ex.Message);
        }
    }

    public List<Cliente> CargarClientes(string rutaArchivo)
    {
        List<Cliente> clientes = new List<Cliente>();
        try
        {
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datosCliente = linea.Split(',');
                    if (datosCliente.Length == 5)
                    {
                        // Extract data from the CSV line
                        int idCliente = int.Parse(datosCliente[0]);
                        string nombre = datosCliente[1];
                        string direccion = datosCliente[2];
                        string telefono = datosCliente[3];
                        string correoElectronico = datosCliente[4];

                        // Create a Cliente object with the extracted data
                        Cliente cliente = new Cliente(idCliente, nombre, direccion, telefono, correoElectronico);

                        clientes.Add(cliente);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar clientes: " + ex.Message);
        }
        return clientes;

    }

public List<Producto> CargarProductos(string rutaArchivoProducto)
    {
        List<Producto> productos = new List<Producto>();
        try
        {
            using (StreamReader lector = new StreamReader(rutaArchivoProducto))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datosProductos = linea.Split(',');
                    if (datosProductos.Length == 4)
                    {
                        // Extract data from the CSV line
                        int idProducto = int.Parse(datosProductos[0]);
                        string nombre = datosProductos[1];
                        double precio = double.Parse(datosProductos[2]);
                        string descripcion = datosProductos[3];

                        // Create a Cliente object with the extracted data
                        Producto producto = new Producto(idProducto, nombre, precio, descripcion);

                        productos.Add(producto);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar clientes: " + ex.Message);
        }
        return productos;

    }

     public List<Pedido> CargarPedidos(string rutaArchivoPedido)
    {
        List<Pedido> pedidos = new List<Pedido>();
        try
        {
            using (StreamReader lector = new StreamReader(rutaArchivoPedido))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datosPedido = linea.Split(',');
                    if (datosPedido.Length == 6)
                    {
                        // Extract data from the CSV line
                        int idPedido = int.Parse(datosPedido[0]);
                        DateTime fechaPedido = DateTime.Parse(datosPedido[1]);
                        int idCliente = int.Parse(datosPedido[2]);
                        string nombreCliente = datosPedido[3];
                        string direccionCliente = datosPedido[4];
                        string telefonoCliente = datosPedido[5];

                        // Create a Cliente object with the extracted data
                        Cliente cliente = new Cliente(idCliente, nombreCliente, direccionCliente, telefonoCliente,"");

                        // Load productos from the pedido
                        List<Producto> productos = CargarProductos(rutaArchivoProducto);

                        // Create a Pedido object with the extracted data
                        Pedido pedido = new Pedido(idPedido, fechaPedido, cliente, productos, 0);

                        pedidos.Add(pedido);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar pedidos: " + ex.Message);
        }
        return pedidos;
    }
}



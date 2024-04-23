
public class Data
{

   public static void GuardarClientes(List<Cliente> clientes)
{
    string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.txt");
    try
    {
        using (StreamWriter escritor = new StreamWriter(rutaArchivo))
        {
            foreach (Cliente cliente in clientes)
            {
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

    public static void GuardarProductos(List<Producto> productos, string rutaProductos)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaProductos))
            {
                foreach (Producto producto in productos)
                {
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


    public static void GuardarPedidos(List<Pedido> pedidos, string rutaPedidos)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaPedidos))
            {
                foreach (Pedido pedido in pedidos)
                {
                    string linea = $"{pedido.IdPedido},{pedido.Cliente.Nombre},{String.Join(",", pedido.Productos.Select(p => p.Nombre))},{pedido.FechaPedido},{pedido.Total}";
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

public static List<Cliente> CargarClientes(string rutaArchivo)
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


}

public class Data
{


    public static void GuardarClientes(List<Cliente> clientes, string rutaClientes)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(rutaClientes))
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


    public static void GuardarDatos(List<Cliente> clientes, List<Producto> productos, List<Pedido> pedidos, string rutaClientes, string rutaProductos, string rutaPedidos)
    {
        GuardarClientes(clientes, rutaClientes);
        GuardarProductos(productos, rutaProductos);
        GuardarPedidos(pedidos, rutaPedidos);
    }

    public static void GuardarClienteHist(List<Cliente> clientes, string rutaClientes)
    {
        using (StreamWriter writer = new StreamWriter(rutaClientes))
        {
            foreach (Cliente cliente in clientes)
            {
                writer.WriteLine($"{cliente.IdCliente}|{cliente.Nombre}");
            }
        }
    }


}
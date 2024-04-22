
class Data {

public static void GuardarClientes(List<Cliente> clientes, string rutaArchivo)
{
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
                string linea = $"{pedido.IdPedido},{pedido.FechaPedido},{pedido.Cliente.IdCliente},{String.Join(",", pedido.Productos.Select(p => p.IdProducto))},{pedido.Total}";
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

}
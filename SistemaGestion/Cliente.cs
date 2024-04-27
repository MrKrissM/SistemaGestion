public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string CorreoElectronico { get; set; }

    public Data data;
    public string rutaArchivoClientes;
    public List<Cliente> clientesExistentes;

    public Cliente(int idCliente, string nombre, string direccion, string telefono, string correoElectronico)
    {
        IdCliente = idCliente;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        CorreoElectronico = correoElectronico;

        data = new Data();
        rutaArchivoClientes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.txt");
        clientesExistentes = data.CargarClientes(rutaArchivoClientes);
    }

    public Cliente()
    {
        IdCliente = 0;
        Nombre = "";
        Direccion = "";
        Telefono = "";
        CorreoElectronico = "";

    }

    public void RegistrarCliente(List<Cliente> clientes)
    {
        try
        {
            Console.WriteLine("Registro de nuevo cliente");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Correo electrónico: ");
            string correoElectronico = Console.ReadLine();

            // Obtener el último ID utilizado en la lista de clientes existente
            int ultimoIdCliente = clientesExistentes.Count > 0 ? clientesExistentes.Max(c => c.IdCliente) : 0;
            int nuevoIdCliente = ultimoIdCliente + 1;
            Cliente nuevoCliente = new Cliente(nuevoIdCliente, nombre, direccion, telefono, correoElectronico);
            // Agrega el nuevo cliente a la lista de clientes existentes
            clientesExistentes.Add(nuevoCliente);
            // Reemplaza la lista original por la lista actualizada
            clientes.Clear();
            clientes.AddRange(clientesExistentes);
            // Guarda la lista actualizada de clientes en el archivo
            data.GuardarClientes(clientes);

            Console.WriteLine("Cliente registrado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al registrar el cliente: " + ex.Message);
        }
    }


     public void ModificarCliente(List<Cliente> clientesExistentes, int idCliente, string nuevoNombre, string nuevaDireccion, string nuevoTelefono, string nuevoCorreoElectronico)
    {
        try
        {

            Cliente clienteAModificar = clientesExistentes.Find(c => c.IdCliente == idCliente);

            if (clienteAModificar != null)
            {
                clienteAModificar.Nombre = nuevoNombre;
                clienteAModificar.Direccion = nuevaDireccion;
                clienteAModificar.Telefono = nuevoTelefono;
                clienteAModificar.CorreoElectronico = nuevoCorreoElectronico;

                // Guarda la lista actualizada de clientes en el archivo
                 data.GuardarClientes(clientesExistentes);

                Console.WriteLine("Cliente modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el cliente con el ID especificado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al modificar el cliente: " + ex.Message);
        }

    }

    public void EliminarCliente(List<Cliente> clientesExistentes, int idCliente)
    {
        try
        {
            Cliente clienteAEliminar = clientesExistentes.Find(c => c.IdCliente == idCliente);

            if (clienteAEliminar != null)
            {
                clientesExistentes.Remove(clienteAEliminar);

                // Guarda la lista actualizada de clientes en el archivo
                data.GuardarClientes(clientesExistentes);

                Console.WriteLine("Cliente eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró el cliente con el ID especificado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al eliminar el cliente: " + ex.Message);
        }

    }

    public void VerListaClientes(List<Cliente> clientes)
    {
        try
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                Console.WriteLine("\nLISTADO DE CLIENTES");
                Console.WriteLine("------------------------");
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.IdCliente}");
                    Console.WriteLine($"Nombre: {cliente.Nombre}");
                    Console.WriteLine($"Dirección: {cliente.Direccion}");
                    Console.WriteLine($"Teléfono: {cliente.Telefono}");
                    Console.WriteLine($"Correo electrónico: {cliente.CorreoElectronico}");
                    Console.WriteLine("------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ver el listado de clientes: " + ex.Message);
        }
    }

}


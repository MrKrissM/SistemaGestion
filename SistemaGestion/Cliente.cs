public class Cliente
{
    private int idCliente;
    private string nombre;
    private string direccion;
    private string telefono;
    private string correoElectronico;

    public Cliente(int idCliente, string nombre, string direccion, string telefono, string correoElectronico)
    {
        this.idCliente = idCliente;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.correoElectronico = correoElectronico;
    }

    public int IdCliente { get => idCliente; set => idCliente = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }

    public static void RegistrarCliente(List<Cliente> clientes)
    {
        try
        {
            // Carga los datos de clientes existentes del archivo (si hay alguno)
            string rutaArchivoClientes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clientes.txt");
            List<Cliente> clientesExistentes = Data.CargarClientes(rutaArchivoClientes);

            // Registra un cliente nuevo como de costumbre
            Console.WriteLine("Registro de nuevo cliente");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Correo electrónico: ");
            string correoElectronico = Console.ReadLine();

            int nuevoIdCliente = clientes.Count + 1; // Suponiendo que los ID comienzan desde 1
            Cliente nuevoCliente = new Cliente(nuevoIdCliente, nombre, direccion, telefono, correoElectronico);
            // Agrega el nuevo cliente a la lista de clientes existentes
            clientesExistentes.Add(nuevoCliente);

            // Reemplaza la lista original por la lista actualizada
            clientes.Clear();
            clientes.AddRange(clientesExistentes);
            // Guarda la lista actualizada de clientes en el archivo
            Data.GuardarClientes(clientes);

            Console.WriteLine("Cliente registrado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al registrar el cliente: " + ex.Message);
        }
    }


    public static void ModificarCliente(List<Cliente> clientes, int idCliente, string nuevoNombre, string nuevaDireccion, string nuevoTelefono, string nuevoCorreoElectronico)
    {
        try
        {
            Cliente clienteAModificar = clientes.Find(c => c.IdCliente == idCliente);

            if (clienteAModificar != null)
            {
                clienteAModificar.Nombre = nuevoNombre;
                clienteAModificar.Direccion = nuevaDireccion;
                clienteAModificar.Telefono = nuevoTelefono;
                clienteAModificar.CorreoElectronico = nuevoCorreoElectronico;

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

    public static void EliminarCliente(List<Cliente> clientes, int idCliente)
    {
        try
        {
            Cliente clienteAEliminar = clientes.Find(c => c.IdCliente == idCliente);

            if (clienteAEliminar != null)
            {
                clientes.Remove(clienteAEliminar);
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
    
    public static void VerListaClientes(List<Cliente> clientes)
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


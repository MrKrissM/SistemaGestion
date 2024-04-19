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
        Console.WriteLine("Registro de nuevo cliente");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Correo electrónico: ");
        string correoElectronico = Console.ReadLine();

        Cliente nuevoCliente = new Cliente(clientes.Count + 1, nombre, direccion, telefono, correoElectronico);
        clientes.Add(nuevoCliente);
        Console.WriteLine("Cliente registrado exitosamente.");
    }

    public static void ModificarCliente(List<Cliente> clientes, int idCliente, string nuevoNombre, string nuevaDireccion, string nuevoTelefono, string nuevoCorreoElectronico)
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

    public static void EliminarCliente(List<Cliente> clientes, int idCliente)
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
}


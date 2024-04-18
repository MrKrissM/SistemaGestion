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

    // Implementar métodos para actualizar y eliminar clientes
}


using LogicaNegocio;
namespace ObligatorioP2

{
    internal class Program
    {
        private static Sistema sistema = new Sistema();

        static void Main(string[] args)
        {
            int inputUsuario = -1;
            while (inputUsuario != 0)
            {
                Menu();
                Console.WriteLine("Digite un número para elegir las siguientes opciones");
                int.TryParse(Console.ReadLine(), out inputUsuario);
                ElegirOpcion(inputUsuario);
            }
            Console.ReadKey();

        }

        static void Menu()
        {
            Console.WriteLine("--- Bienvenido ---");
            Console.WriteLine("1 - Listado de todos los clientes.");
            Console.WriteLine("2 - Consultar vuelos del aeropuerto.");
            Console.WriteLine("3 - Dar de alta a un cliente ocasional.");
            Console.WriteLine("4 - Listar pasajes por fecha.");
            Console.WriteLine("0 - Salir.");
        }
        static void ElegirOpcion(int inputUsuario)
        {
            switch (inputUsuario)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    ConsultarVuelos();
                    break;
                case 3:
                    RegistrarClienteOcasional();
                    break;
                case 4:
                    ListarPasajesPorFechas();
                    break;
                default:
                    Console.Clear();
                    break;

            }
        }
        //Listado de todos los clientes
        static void ListarClientes()
        {
            Console.WriteLine("Clientes Premium:\n");
            foreach (ClientePremium cliente in sistema.ClientesPremium())
            {
                Console.WriteLine(cliente);
            }

            Console.WriteLine("\nClientes Ocasionales:\n");
            foreach (ClienteOcasional cliente in sistema.ClientesOcasionales())
            {
                Console.WriteLine(cliente);
            }
        }

        //Consultar vuelos en aeropuerto
        static void ConsultarVuelos()
        {
            try
            {
                Console.WriteLine("Ingrese un codigo de aeropuerto");
                string codigo = Console.ReadLine().ToUpper();
                Aeropuerto aeropuerto = sistema.GetAeropuertoPorCodigo(codigo);

                Console.WriteLine("Vuelos en este aeropuerto:");
                foreach (Vuelo vuelo in sistema.MostrarVuelosEnAeropuerto(aeropuerto))
                {
                    Console.WriteLine($"Número vuelo: {vuelo.NumeroVuelo}, Modelo del avión: {vuelo.Avion.Modelo}," +
                                     $" Ruta: {vuelo.Ruta.AeropuertoSalida.CodigoIATA} - {vuelo.Ruta.AeropuertoLlegada.CodigoIATA}," +
                                     $" Frecuencia: {vuelo.Frecuencia}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Alta Cliente Ocasional
        static void RegistrarClienteOcasional()
        {
            try
            {
                Console.WriteLine("Ingrese el correo:");
                string correo = Console.ReadLine();
                Console.WriteLine("Ingrese una contrasena:");
                string contrasena = Console.ReadLine();
                Console.WriteLine("Ingrese su documento:");
                string documento = Console.ReadLine();
                Console.WriteLine("Ingrese su nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese su nacionalidad:");
                string nacionalidad = Console.ReadLine();

                ClienteOcasional cliente = new ClienteOcasional(correo, contrasena, documento, nombre, nacionalidad);
                sistema.AltaClienteOcasional(cliente);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Listar pasajes por fechas
        static void ListarPasajesPorFechas()
        {
            Console.WriteLine("Ingrese la primera fecha: (dd/mm/yyyy)");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde);
            Console.WriteLine("Ingrese la segunda fecha: (dd/mm/yyyy)");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta);

            if (fechaDesde.ToString() != null && fechaHasta.ToString() != null)
            {
                Console.WriteLine($"Pasajes comprendidos entre las fechas: {fechaDesde.ToShortDateString()} - {fechaHasta.ToShortDateString()}:");
                foreach (Pasaje pasaje in sistema.PasajesFiltradosPorFecha(fechaDesde, fechaHasta))
                {
                    Console.WriteLine(pasaje);
                }
            }
            

        }
    }
}






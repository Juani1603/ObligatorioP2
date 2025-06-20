using LogicaNegocio.Enum;

namespace LogicaNegocio
{
    public class Sistema
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Avion> _aviones = new List<Avion>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
        private List<Pasaje> _pasajes = new List<Pasaje>();
        private static Sistema _instancia;

        public List<Vuelo> Vuelos
        {
            get { return _vuelos; }
        }

        public List<Pasaje> Pasajes
        {
            get { return _pasajes; }
        }

        public List<Usuario> Usuarios
        {
            get { return _usuarios; }
        }

        private Sistema()
        {
            PrecargaUsuarios();
            PrecargaAviones();
            PrecargaAeropuertos();
            PrecargaRutas();
            PrecargaVuelos();
            PrecargaPasajes();
        }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        //Precarga de datos
        private void PrecargaUsuarios()
        {
            //2 Administradores
            _usuarios.Add(new Administrador("admin1@correo.com", "pass123", "Admin", "SuperAdmin"));
            _usuarios.Add(new Administrador("admin2@correo.com", "clave456", "Admin", "JefeSistema"));
            //5 Clientes Premium
            _usuarios.Add(new ClientePremium("luis@gmail.com", "1234", "Cliente", "45678901", "Luis Fernández", "Uruguaya", 1500));
            _usuarios.Add(new ClientePremium("ana@hotmail.com", "abcd", "Cliente", "12345678", "Ana García", "Argentina", 2300));
            _usuarios.Add(new ClientePremium("pedro@outlook.com", "qwerty", "Cliente", "78912345", "Pedro Martínez", "Chilena", 900));
            _usuarios.Add(new ClientePremium("sofia@mail.com", "sofia2025", "Cliente", "32165498", "Sofía López", "Uruguaya", 3100));
            _usuarios.Add(new ClientePremium("matias@correo.com", "matpass", "Cliente", "65478932", "Matías Castro", "Paraguaya", 200));
            // 5 Clientes Ocasionales
            _usuarios.Add(new ClienteOcasional("camila@gmail.com", "cami123", "Cliente", "11223344", "Camila Suárez", "Uruguaya"));
            _usuarios.Add(new ClienteOcasional("daniel@yahoo.com", "danielito", "Cliente", "99887766", "Daniel Pérez", "Argentina"));
            _usuarios.Add(new ClienteOcasional("valentina@mail.com", "valen456", "Cliente", "44556677", "Valentina Ríos", "Chilena"));
            _usuarios.Add(new ClienteOcasional("federico@correo.com", "fede789", "Cliente", "77665544", "Federico Gómez", "Uruguaya"));
            _usuarios.Add(new ClienteOcasional("julieta@hotmail.com", "julie321", "Cliente", "33442211", "Julieta Fernández", "Boliviana"));
        }

        private void PrecargaAviones()
        {
            //4 Aviones
            _aviones.Add(new Avion("Boeing", "737-800", 160, 5435.0, 8.5));
            _aviones.Add(new Avion("Airbus", "A320neo", 180, 6300.0, 9.2));
            _aviones.Add(new Avion("Embraer", "E195-E2", 132, 4800.0, 7.0));
            _aviones.Add(new Avion("Bombardier", "CRJ1000", 100, 3100.0, 6.3));
        }

        private void PrecargaAeropuertos()
        {
            //20 Aeropuertos
            _aeropuertos.Add(new Aeropuerto("MVD", "Montevideo", 5000.0, 1200.0));
            _aeropuertos.Add(new Aeropuerto("EZE", "Buenos Aires", 7000.0, 1500.0));
            _aeropuertos.Add(new Aeropuerto("GRU", "São Paulo", 8000.0, 1800.0));
            _aeropuertos.Add(new Aeropuerto("SCL", "Santiago", 7500.0, 1600.0));
            _aeropuertos.Add(new Aeropuerto("LIM", "Lima", 7200.0, 1400.0));
            _aeropuertos.Add(new Aeropuerto("BOG", "Bogotá", 7800.0, 1700.0));
            _aeropuertos.Add(new Aeropuerto("MEX", "Ciudad de México", 8500.0, 2000.0));
            _aeropuertos.Add(new Aeropuerto("JFK", "Nueva York", 12000.0, 2500.0));
            _aeropuertos.Add(new Aeropuerto("LAX", "Los Ángeles", 13000.0, 2600.0));
            _aeropuertos.Add(new Aeropuerto("MAD", "Madrid", 11000.0, 2400.0));
            _aeropuertos.Add(new Aeropuerto("CDG", "París", 11500.0, 2450.0));
            _aeropuertos.Add(new Aeropuerto("FRA", "Frankfurt", 11300.0, 2300.0));
            _aeropuertos.Add(new Aeropuerto("LHR", "Londres", 12500.0, 2550.0));
            _aeropuertos.Add(new Aeropuerto("BCN", "Barcelona", 10500.0, 2200.0));
            _aeropuertos.Add(new Aeropuerto("ROM", "Roma", 9800.0, 2100.0));
            _aeropuertos.Add(new Aeropuerto("PTY", "Panamá", 6900.0, 1500.0));
            _aeropuertos.Add(new Aeropuerto("MIA", "Miami", 11800.0, 2350.0));
            _aeropuertos.Add(new Aeropuerto("DFW", "Dallas", 11900.0, 2400.0));
            _aeropuertos.Add(new Aeropuerto("YYZ", "Toronto", 10800.0, 2200.0));
            _aeropuertos.Add(new Aeropuerto("AMS", "Ámsterdam", 11400.0, 2450.0));
        }

        private void PrecargaRutas()
        {
            //30 Rutas
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("EZE"), 230));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("GRU"), 1560));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("SCL"), 1370));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("JFK"), 8320));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("EZE"), GetAeropuertoPorCodigo("JFK"), 8590));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("GRU"), GetAeropuertoPorCodigo("CDG"), 9400));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("GRU"), GetAeropuertoPorCodigo("MIA"), 6540));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("SCL"), GetAeropuertoPorCodigo("MAD"), 10700));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("JFK"), GetAeropuertoPorCodigo("LHR"), 5540));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("CDG"), GetAeropuertoPorCodigo("LHR"), 340));

            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MAD"), GetAeropuertoPorCodigo("MVD"), 5700));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MIA"), GetAeropuertoPorCodigo("LAX"), 3760));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("LAX"), GetAeropuertoPorCodigo("AMS"), 8780));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("LHR"), GetAeropuertoPorCodigo("MIA"), 17000));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("PTY"), GetAeropuertoPorCodigo("BOG"), 5840));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("ROM"), GetAeropuertoPorCodigo("LHR"), 5300));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("LIM"), GetAeropuertoPorCodigo("MVD"), 2160));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("BOG"), GetAeropuertoPorCodigo("SCL"), 9700));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("BOG"), 5200));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("BOG"), GetAeropuertoPorCodigo("JFK"), 4010));

            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MVD"), GetAeropuertoPorCodigo("LAX"), 8900));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("SCL"), GetAeropuertoPorCodigo("GRU"), 2300));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("SCL"), GetAeropuertoPorCodigo("MIA"), 6400));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("GRU"), GetAeropuertoPorCodigo("LHR"), 9500));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("EZE"), GetAeropuertoPorCodigo("MAD"), 10780));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("MIA"), GetAeropuertoPorCodigo("BOG"), 13900));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("JFK"), GetAeropuertoPorCodigo("LAX"), 11000));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("LAX"), GetAeropuertoPorCodigo("YYZ"), 560));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("BOG"), GetAeropuertoPorCodigo("MVD"), 5200));
            _rutas.Add(new Ruta(GetAeropuertoPorCodigo("LHR"), GetAeropuertoPorCodigo("JFK"), 5500));
        }

        private void PrecargaVuelos()
        {
            //30 Vuelos
            _vuelos.Add(new Vuelo("AR123", GetRutaPorId(1), GetAvionPorFabricante("Boeing"), DiaSemana.Lunes));
            _vuelos.Add(new Vuelo("LA45", GetRutaPorId(2), GetAvionPorFabricante("Airbus"), DiaSemana.Martes));
            _vuelos.Add(new Vuelo("UY1", GetRutaPorId(3), GetAvionPorFabricante("Embraer"), DiaSemana.Miercoles));
            _vuelos.Add(new Vuelo("BR777", GetRutaPorId(4), GetAvionPorFabricante("Boeing"), DiaSemana.Jueves));
            _vuelos.Add(new Vuelo("IB200", GetRutaPorId(5), GetAvionPorFabricante("Airbus"), DiaSemana.Viernes));
            _vuelos.Add(new Vuelo("AA2", GetRutaPorId(6), GetAvionPorFabricante("Boeing"), DiaSemana.Sabado));
            _vuelos.Add(new Vuelo("UX380", GetRutaPorId(7), GetAvionPorFabricante("Airbus"), DiaSemana.Domingo));
            _vuelos.Add(new Vuelo("EK99", GetRutaPorId(8), GetAvionPorFabricante("Embraer"), DiaSemana.Lunes));
            _vuelos.Add(new Vuelo("QF1", GetRutaPorId(9), GetAvionPorFabricante("Boeing"), DiaSemana.Martes));
            _vuelos.Add(new Vuelo("NZ202", GetRutaPorId(10), GetAvionPorFabricante("Airbus"), DiaSemana.Miercoles));

            _vuelos.Add(new Vuelo("AF35", GetRutaPorId(11), GetAvionPorFabricante("Boeing"), DiaSemana.Jueves));
            _vuelos.Add(new Vuelo("LH4", GetRutaPorId(12), GetAvionPorFabricante("Airbus"), DiaSemana.Viernes));
            _vuelos.Add(new Vuelo("DL310", GetRutaPorId(13), GetAvionPorFabricante("Boeing"), DiaSemana.Sabado));
            _vuelos.Add(new Vuelo("AV567", GetRutaPorId(14), GetAvionPorFabricante("Embraer"), DiaSemana.Domingo));
            _vuelos.Add(new Vuelo("TP88", GetRutaPorId(15), GetAvionPorFabricante("Boeing"), DiaSemana.Lunes));
            _vuelos.Add(new Vuelo("AC500", GetRutaPorId(16), GetAvionPorFabricante("Airbus"), DiaSemana.Martes));
            _vuelos.Add(new Vuelo("AZ900", GetRutaPorId(17), GetAvionPorFabricante("Embraer"), DiaSemana.Miercoles));
            _vuelos.Add(new Vuelo("IB20", GetRutaPorId(18), GetAvionPorFabricante("Boeing"), DiaSemana.Jueves));
            _vuelos.Add(new Vuelo("AF75", GetRutaPorId(19), GetAvionPorFabricante("Airbus"), DiaSemana.Viernes));
            _vuelos.Add(new Vuelo("LH150", GetRutaPorId(20), GetAvionPorFabricante("Embraer"), DiaSemana.Sabado));

            _vuelos.Add(new Vuelo("AR10", GetRutaPorId(21), GetAvionPorFabricante("Boeing"), DiaSemana.Domingo));
            _vuelos.Add(new Vuelo("LA11", GetRutaPorId(22), GetAvionPorFabricante("Airbus"), DiaSemana.Lunes));
            _vuelos.Add(new Vuelo("UY22", GetRutaPorId(23), GetAvionPorFabricante("Embraer"), DiaSemana.Martes));
            _vuelos.Add(new Vuelo("BR33", GetRutaPorId(24), GetAvionPorFabricante("Boeing"), DiaSemana.Miercoles));
            _vuelos.Add(new Vuelo("IB44", GetRutaPorId(25), GetAvionPorFabricante("Airbus"), DiaSemana.Jueves));
            _vuelos.Add(new Vuelo("AA55", GetRutaPorId(26), GetAvionPorFabricante("Boeing"), DiaSemana.Viernes));
            _vuelos.Add(new Vuelo("UX66", GetRutaPorId(27), GetAvionPorFabricante("Airbus"), DiaSemana.Sabado));
            _vuelos.Add(new Vuelo("EK77", GetRutaPorId(28), GetAvionPorFabricante("Embraer"), DiaSemana.Domingo));
            _vuelos.Add(new Vuelo("QF88", GetRutaPorId(29), GetAvionPorFabricante("Boeing"), DiaSemana.Lunes));
            _vuelos.Add(new Vuelo("NZ99", GetRutaPorId(30), GetAvionPorFabricante("Airbus"), DiaSemana.Martes));
        }

        private void PrecargaPasajes()
        {
            // Precarga de 25 pasajes
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AR123"), new DateTime(2025, 4, 14), GetClientePorDocumento("12345678"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("LA45"), new DateTime(2025, 4, 15), GetClientePorDocumento("45678901"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("UY1"), new DateTime(2025, 4, 16), GetClientePorDocumento("78912345"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("BR777"), new DateTime(2025, 4, 17), GetClientePorDocumento("65478932"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("IB200"), new DateTime(2025, 4, 18), GetClientePorDocumento("77665544"), Equipaje.CABINA));

            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AA2"), new DateTime(2025, 4, 19), GetClientePorDocumento("11223344"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("UX380"), new DateTime(2025, 4, 20), GetClientePorDocumento("65478932"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("EK99"), new DateTime(2025, 4, 21), GetClientePorDocumento("78912345"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("QF1"), new DateTime(2025, 4, 22), GetClientePorDocumento("33442211"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("NZ202"), new DateTime(2025, 4, 23), GetClientePorDocumento("12345678"), Equipaje.LIGHT));

            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AF35"), new DateTime(2025, 4, 24), GetClientePorDocumento("45678901"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("LH4"), new DateTime(2025, 4, 25), GetClientePorDocumento("78912345"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("DL310"), new DateTime(2025, 4, 26), GetClientePorDocumento("65478932"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AV567"), new DateTime(2025, 4, 27), GetClientePorDocumento("44556677"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("TP88"), new DateTime(2025, 4, 28), GetClientePorDocumento("77665544"), Equipaje.BODEGA));

            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AC500"), new DateTime(2025, 4, 29), GetClientePorDocumento("32165498"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AZ900"), new DateTime(2025, 4, 30), GetClientePorDocumento("11223344"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("IB20"), new DateTime(2025, 5, 1), GetClientePorDocumento("44556677"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AF75"), new DateTime(2025, 5, 2), GetClientePorDocumento("99887766"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("LH150"), new DateTime(2025, 5, 3), GetClientePorDocumento("33442211"), Equipaje.CABINA));

            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("AR10"), new DateTime(2025, 5, 4), GetClientePorDocumento("45678901"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("LA11"), new DateTime(2025, 5, 5), GetClientePorDocumento("65478932"), Equipaje.LIGHT));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("UY22"), new DateTime(2025, 5, 6), GetClientePorDocumento("99887766"), Equipaje.CABINA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("BR33"), new DateTime(2025, 5, 7), GetClientePorDocumento("44556677"), Equipaje.BODEGA));
            _pasajes.Add(new Pasaje(GetVueloPorNumeroVuelo("IB44"), new DateTime(2025, 5, 8), GetClientePorDocumento("33442211"), Equipaje.LIGHT));
        }

        //Método para mostrar clientes
        //Premium
        public List<ClientePremium> ClientesPremium()
        {
            List<ClientePremium> premium = new List<ClientePremium>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is ClientePremium clientePremium)
                {
                    premium.Add(clientePremium);
                }
            }

            if (premium.Count == 0)
            {
                throw new Exception("La lista de clientes premium está vacía");
            }

            return premium;
        }
        //Ocasionales
        public List<ClienteOcasional> ClientesOcasionales()
        {
            List<ClienteOcasional> ocasionales = new List<ClienteOcasional>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is ClienteOcasional clienteOcasional)
                {
                    ocasionales.Add(clienteOcasional);
                }
                if (ocasionales.Count == 0)
                {
                    throw new Exception("La lista de clientes ocasionales está vacía");
                }
            }
            return ocasionales;

        }

        //Alta Usuarios
        public void AltaAdministrador(Administrador admin)
        {
            admin.DefinirRolUsuario();
            admin.Validar();
            if (!_usuarios.Contains(admin))
            {
                _usuarios.Add(admin);
            }
            else
            {
                throw new Exception("Ya hay un administrador registrado con ese correo.");
            }
        }

        public void AltaClientePremium(ClientePremium cliente)
        {
            cliente.DefinirRolUsuario();
            cliente.Validar();
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
            else
            {
                throw new Exception("Ya hay un cliente registrado con ese correo.");
            }
        }

        public void AltaClienteOcasional(ClienteOcasional cliente)
        {
            cliente.DefinirRolUsuario();
            cliente.Validar();
            if (!_usuarios.Contains(cliente))
            {
                _usuarios.Add(cliente);
            }
            else
            {
                throw new Exception("Ya hay un cliente registrado con ese correo.");
            }
        }
        //Alta Aeropuertos
        public void AltaAeropuerto(Aeropuerto aeropuerto)
        {
            aeropuerto.Validar();
            if (!_aeropuertos.Contains(aeropuerto))
            {
                _aeropuertos.Add(aeropuerto);
            }
            else
            {
                throw new Exception("Ya hay un aeropuerto registrado con ese código IATA.");
            }
        }

        //Alta Aviones
        public void AltaAvion(Avion avion)
        {
            avion.Validar();
            if (!_aviones.Contains(avion))
            {
                _aviones.Add(avion);
            }
            else
            {
                throw new Exception("Ya hay un avión registrado con ese fabricante.");
            }
        }


        //Alta Vuelos
        public void AltaVuelo(Vuelo vuelo)
        {
            vuelo.Validar();
            vuelo.VerificarAlcanceVuelo();
            if (!_vuelos.Contains(vuelo))
            {
                _vuelos.Add(vuelo);
            }
            else
            {
                throw new Exception("Ya hay un vuelo registrado con ese número.");
            }
        }
        //Alta Rutas
        public void AltaRuta(Ruta ruta)
        {
            ruta.Validar();
            if (!_rutas.Contains(ruta))
            {
                _rutas.Add(ruta);
            }
            else
            {
                throw new Exception("Ya hay una ruta registrada con ese ID.");
            }
        }
        //Alta Pasajes
        public void AltaPasaje(Pasaje pasaje)
        {
            pasaje.VerificarFrecuenciaVuelo();
            pasaje.Validar();
            if (!_pasajes.Contains(pasaje))
            {
                _pasajes.Add(pasaje);
            }
            else
            {
                throw new Exception("Ya hay un pasaje registrado con ese ID.");
            }
        }

        //Buscar Aeropuerto por código IATA
        private Aeropuerto BuscarAeropuerto(string codigoIATA)
        {
            Aeropuerto aeropuerto = null;
            int i = 0;
            while (i < _aeropuertos.Count && aeropuerto == null)
            {
                if (_aeropuertos[i].CodigoIATA == codigoIATA)
                {
                    aeropuerto = _aeropuertos[i];
                }
                i++;
            }
            return aeropuerto;
        }

        public Aeropuerto GetAeropuertoPorCodigo(string codigoIATA)
        {
            Aeropuerto aeropuerto = BuscarAeropuerto(codigoIATA);

            if (aeropuerto != null)
            {
                return aeropuerto;
            }
            else
            {
                throw new Exception($"Aeropuerto con código {codigoIATA} no encontrado.");
            }
        }

        //Buscar Avión por fabricante
        private Avion BuscarAvion(string fabricante)
        {
            Avion avion = null;
            int i = 0;
            while (i < _aviones.Count && avion == null)
            {
                if (_aviones[i].Fabricante == fabricante)
                {
                    avion = _aviones[i];
                }
                i++;
            }
            return avion;
        }
        public Avion GetAvionPorFabricante(string fabricante)
        {
            Avion avion = BuscarAvion(fabricante);

            if (avion != null)
            {
                return avion;
            }
            else
            {
                throw new Exception($"Avión con fabricante '{fabricante}' no encontrado.");
            }
        }

        //Buscar Ruta por ID
        private Ruta BuscarRuta(int id)
        {
            Ruta ruta = null;
            int i = 0;
            while (i < _rutas.Count && ruta == null)
            {
                if (_rutas[i].ID == id)
                {
                    ruta = _rutas[i];
                }
                i++;
            }
            return ruta;
        }

        public Ruta GetRutaPorId(int id)
        {
            Ruta ruta = BuscarRuta(id);

            if (ruta != null)
            {
                return ruta;
            }
            else
            {
                throw new Exception($"Ruta con ID {id} no encontrada.");
            }
        }

        //Buscar Vuelo por numeroVuelo
        private Vuelo BuscarVuelo(string numeroVuelo)
        {
            Vuelo vuelo = null;
            int i = 0;
            while (i < _vuelos.Count && vuelo == null)
            {
                if (_vuelos[i].NumeroVuelo == numeroVuelo)
                {
                    vuelo = _vuelos[i];
                }
                i++;
            }
            return vuelo;
        }

        public Vuelo GetVueloPorNumeroVuelo(string numeroVuelo)
        {
            Vuelo vuelo = BuscarVuelo(numeroVuelo);

            if (vuelo != null)
            {
                return vuelo;
            }
            else
            {
                throw new Exception($"El vuelo con el número {numeroVuelo} no fué encontrado.");
            }
        }

        //Buscar Cliente por documento
        public Cliente GetClientePorDocumento(string documento)
        {
            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente cliente && cliente.Documento == documento)
                {
                    return cliente;
                }
            }
            throw new Exception($"El cliente con el documento {documento} no fué encontrado.");
        }

        //Buscar Usuario por correo
        private Usuario BuscarUsuarioPorCorreo(string correo)
        {
            Usuario usuarioBuscado = null;
            int i = 0;

            while (i < _usuarios.Count && usuarioBuscado == null)
            {
                if (_usuarios[i].Correo == correo)
                {
                    usuarioBuscado = _usuarios[i];
                }
                i++;
            }

            return usuarioBuscado;
        }

        public Usuario GetUsuarioEnSesion(string correo)
        {
            Usuario usuario = BuscarUsuarioPorCorreo(correo);

            if (usuario != null)
            {
                return usuario;
            }
            else
            {
                throw new Exception($"No se encontró ningún usuario con el correo {correo}.");
            }
        }

        //Buscar Cliente por correo
        private Cliente BuscarClientePorCorreo(string correo)
        {
            Cliente clienteBuscado = null;
            int i = 0;

            while (i < _usuarios.Count && clienteBuscado == null)
            {
                if (_usuarios[i].Correo == correo && _usuarios[i] is Cliente cliente)
                {
                    clienteBuscado = cliente;
                }
                i++;
            }

            return clienteBuscado;
        }

        public Cliente GetClientePorCorreo(string correo)
        {
            Cliente cliente = BuscarClientePorCorreo(correo);

            if (cliente != null)
            {
                return cliente;
            }
            else
            {
                throw new Exception("No se encontró ningún cliente con ese correo.");
            }
        }


        //Lista de vuelos según el código de aeropuerto
        public List<Vuelo> BuscarVuelosPorRuta(string codigoSalida, string codigoLlegada)
        {
            List<Vuelo> resultado = new List<Vuelo>();

            foreach (Vuelo vuelo in _vuelos)
            {
                bool coincideSalida = string.IsNullOrEmpty(codigoSalida) || vuelo.Ruta.AeropuertoSalida.CodigoIATA.Equals(codigoSalida.ToUpper());
                bool coincideLlegada = string.IsNullOrEmpty(codigoLlegada) || vuelo.Ruta.AeropuertoLlegada.CodigoIATA.Equals(codigoLlegada.ToUpper());

                // Si se ingresan ambos, deben coincidir ambos
                if (!string.IsNullOrEmpty(codigoSalida) && !string.IsNullOrEmpty(codigoLlegada))
                {
                    if (coincideSalida && coincideLlegada)
                        resultado.Add(vuelo);
                }
                else if (!string.IsNullOrEmpty(codigoSalida) && coincideSalida)
                {
                    resultado.Add(vuelo);
                }
                else if (!string.IsNullOrEmpty(codigoLlegada) && coincideLlegada)
                {
                    resultado.Add(vuelo);
                }
            }

            return resultado;
        }

        //Lista de pasajes según rango de fechas
        public List<Pasaje> PasajesFiltradosPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Pasaje> pasajes = new List<Pasaje>();
            foreach (Pasaje pasaje in _pasajes)
            {
                if (pasaje.Fecha >= fechaDesde && pasaje.Fecha <= fechaHasta)
                {
                    pasajes.Add(pasaje);
                }
            }
            if (pasajes.Count == 0)
            {
                throw new Exception("No hay pasajes comprendidos en esas fechas.");
            }
            return pasajes;
        }

        public string Login(string correo, string password)
        {
            bool existe = false;
            int i = 0;
            string rol = "";

            while (i < _usuarios.Count && !existe)
            {
                if (_usuarios[i].Correo.Equals(correo) && _usuarios[i].Contrasena.Equals(password))
                {
                    existe = true;
                    rol = _usuarios[i].Rol;
                }
                i++;
            }
            return rol;
        }

        public List<Pasaje> BuscarPasajesPorCliente(Cliente cliente)
        {
            List<Pasaje> pasajesCliente = new List<Pasaje>();

            foreach (Pasaje pasaje in _pasajes)
            {
                if (pasaje.Pasajero.Equals(cliente))
                {
                    pasajesCliente.Add(pasaje);
                }
            }

            return pasajesCliente;
        }

        public List<Pasaje> PasajesOrdenadosPorFecha()
        {
            List<Pasaje> pasajes = new List<Pasaje>(_pasajes);
            pasajes.Sort(new OrdenamientoPasajePorFecha());
            return pasajes;
        }

        public List<Cliente> TodosLosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (Usuario usuario in _usuarios)
            {
                if (usuario is Cliente cliente)
                {
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }

        public string TipoCliente(Cliente cliente)
        {
            return cliente.GetType().Name; 
        }
    }
}
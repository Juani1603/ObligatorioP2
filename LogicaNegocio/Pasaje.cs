using LogicaNegocio.Enum;

namespace LogicaNegocio
{
    public class Pasaje
    {
        private int _id;
        private static int s_contadorId;
        private Vuelo _vuelo;
        private DateTime _fecha;
        private Cliente _pasajero;
        private Equipaje _equipaje;
        private double _precio;
        private static double _margenGanancia = 1.25;

        public DateTime Fecha
        {
            get { return _fecha; }
        }

        public Equipaje Equipaje
        {
            get { return _equipaje; }
        }


        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
        {
            _id = s_contadorId++;
            _vuelo = vuelo;
            _fecha = fecha;
            _pasajero = pasajero;
            _equipaje = equipaje;
        }

        //Métodos para calcular precio pasaje
        public double CalcularPrecioBasePasaje()
        {
            return _vuelo.CalcularCostoPorAsiento() * _margenGanancia;
        }

        public double CalcularImpuestosPasaje()
        {
            return _vuelo.CalcularTasasRuta();
        }

        public double CalcularPrecioFinal(Pasaje pasaje)
        {
            double precio = CalcularPrecioBasePasaje() + CalcularImpuestosPasaje();

            precio *= _pasajero.ImpuestoPasajePorCliente(pasaje);

            return precio;
        }


        public bool VerificarFrecuenciaVuelo()
        {
            // Casteo para comparar días
            DiaSemana diaDelPasaje = (DiaSemana)_fecha.DayOfWeek;

            if (diaDelPasaje != _vuelo.Frecuencia)
            {
                throw new Exception($"La fecha del pasaje no coincide con la frecuencia del vuelo. Día del pasaje: {diaDelPasaje}, frecuencia del vuelo: {_vuelo.Frecuencia}");
            }

            return true;
        }


        public void Validar()
        {
            if (_vuelo == null)
            {
                throw new Exception("El vuelo no puede ser nulo.");
            }
            if (_pasajero == null)
            {
                throw new Exception("El pasajero no puede ser nulo.");
            }
            if (_precio <= 0)
            {
                throw new Exception("El precio debe tener un valor numero mayor a cero.");
            }

        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Pasaje)
            {
                Pasaje pasaje = (Pasaje)obj;
                sonIguales = _id.Equals(pasaje._id);
            }
            return sonIguales;
        }

        public override string ToString()
        {
            return $"ID: {_id}, Nombre del pasajero: {_pasajero.Nombre}, Precio: ${_precio}, Fecha: {_fecha.ToShortDateString()}, Número de vuelo: {_vuelo.NumeroVuelo}";
        }

    }
}

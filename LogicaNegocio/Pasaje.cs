using LogicaNegocio.Enum;

namespace LogicaNegocio
{
    public class Pasaje : IComparable<Pasaje>
    {
        private int _id;
        private static int s_contadorId;
        private Vuelo _vuelo;
        private DateTime _fecha;
        private Cliente _pasajero;
        private Equipaje _equipaje;
        private double _precio;
        private static double s_margenGanancia = 1.25;

        public Vuelo Vuelo
        {
            get { return _vuelo; }
            set { _vuelo = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set {  _fecha = value; }
        }

        public Cliente Pasajero
        {
            get { return _pasajero; }
            set { _pasajero = value; }  
        }

        public Equipaje Equipaje
        {
            get { return _equipaje; }
            set { _equipaje = value; }
        }

        public double Precio
        {
            get { return _precio; }
        }

        public Pasaje() { }

        public Pasaje(Vuelo vuelo, DateTime fecha, Cliente pasajero, Equipaje equipaje)
        {
            _id = s_contadorId++;
            _vuelo = vuelo;
            _fecha = fecha;
            _pasajero = pasajero;
            _equipaje = equipaje;
            _precio = DefinirPrecioFinal();
        }

        //Métodos para calcular precio pasaje
        public double CalcularPrecioBasePasaje()
        {
            return _vuelo.CalcularCostoPorAsiento() * s_margenGanancia;
        }

        public double CalcularImpuestosPasaje()
        {
            return _vuelo.CalcularTasasRuta();
        }

        public double DefinirPrecioFinal()
        {
            double precio = CalcularPrecioBasePasaje() + CalcularImpuestosPasaje();

            precio *= _pasajero.ImpuestoPasajePorCliente(this);

            return Math.Round(precio, 2);
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
            if (_fecha == DateTime.MinValue)
            {
                throw new Exception("La fecha no es válida");
            }
            if (_fecha.Date < DateTime.Today)
            {
                throw new Exception("La fecha ingresada no puede ser menor a la fecha actual.");
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

        public int CompareTo(Pasaje? other)
        {
            return (_precio.CompareTo(other._precio)) * -1;
        }
    }
}

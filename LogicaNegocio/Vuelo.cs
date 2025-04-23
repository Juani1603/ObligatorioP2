using LogicaNegocio.Enum;

namespace LogicaNegocio
{
    public class Vuelo
    {
        private string _numeroVuelo;
        private Ruta _ruta;
        private Avion _avion;
        private DiaSemana _frecuencia;

        public string NumeroVuelo
        {
            get {  return _numeroVuelo; } 
        }

            public Ruta Ruta
            {
                get { return _ruta; }
            }

        public Avion Avion
        {
            get { return _avion; }
        }
        public DiaSemana Frecuencia
        {
            get { return _frecuencia; }
        }
        public Vuelo(string numeroVuelo, Ruta ruta, Avion avion, DiaSemana frecuencia)
        {
            _numeroVuelo = numeroVuelo;
            _ruta = ruta;
            _avion = avion;
            _frecuencia = frecuencia;
        }

        public void Validar()
        {
            //Validaciones de número de vuelo
            if (_numeroVuelo.Length < 3 || _numeroVuelo.Length > 6)
            {
                throw new Exception("El número de vuelo debe tener entre 3 y 6 caracteres.");
            }

            int contadorLetras = 0;
            int contadorNumeros = 0;

            for (int i = 0; i < _numeroVuelo.Length; i++)
            {
                if (char.IsLetter(_numeroVuelo[i]))
                {
                    contadorLetras++;
                }
                if (char.IsDigit(_numeroVuelo[i]))
                {
                    contadorNumeros++;
                }
            }

            if (contadorLetras >= 3 || contadorLetras <= 1)
            {
                throw new Exception("El número de vuelo debe contar con 2 letras.");
            }
            if (contadorNumeros < 1 || contadorNumeros > 4)
            {
                throw new Exception("El número de vuelo debe estar compuesto entre 1 y 4 números");
            }

            if (_ruta == null)
            {
                throw new Exception("La ruta no puede ser nula.");
            }

            if (_avion == null)
            {
                throw new Exception("El avión no puede ser nulo.");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;

            if (obj != null && obj is Vuelo)
            {
                Vuelo vuelo = (Vuelo)obj;
                sonIguales = _numeroVuelo.Equals(vuelo._numeroVuelo);
            }

            return sonIguales;
        }

        public double 
            CalcularCostoPorAsiento()
        {
            double costoAsiento = ((_avion.CostoOperacionKm * _ruta.DistanciaRuta) + (_ruta.AeropuertoSalida.CostoOperacion + _ruta.AeropuertoLlegada.CostoOperacion))
                                    / _avion.CantidadAsientos;

            return costoAsiento;
        }

        public bool VerificarAlcanceVuelo()
        {
            bool puedeVolar = false;
            if (_avion.AlcanceKM >= _ruta.DistanciaRuta)
            {
                puedeVolar = true;
            }

            return puedeVolar;
        }
    }
}

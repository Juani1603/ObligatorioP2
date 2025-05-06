namespace LogicaNegocio
{
    public class Aeropuerto
    {
        private string _codigoIATA;
        private string _ciudad;
        private double _costoOperacion;
        private double _costoTasas;

        public string CodigoIATA
        {
            get { return _codigoIATA; }
        }
        public double CostoOperacion
        {
            get { return _costoOperacion; }
        }

        public double CostoTasas
        {
            get { return _costoTasas; }
        }

        public Aeropuerto(string codigoIATA, string ciudad, double costoOperacion, double costoTasas)
        {
            _codigoIATA = codigoIATA;
            _ciudad = ciudad;
            _costoOperacion = costoOperacion;
            _costoTasas = costoTasas;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_codigoIATA))
            {
                throw new Exception("El campo de codigo IATA no puede estar vacío.");

            }

            if (_codigoIATA.Length != 3)
            {
                throw new Exception("El códgio IATA es inválido.");
            }

            if (string.IsNullOrEmpty(_ciudad))
            {
                throw new Exception("El campo de ciudad no puede estar vacío.");

            }
            if (_costoOperacion <= 0)
            {
                throw new Exception("El costo de la operacion debe ser un valor numerico mayor a cero.");
            }
            if (_costoTasas <= 0)
            {
                throw new Exception("El costo de tasas debe ser un valor numerico mayor a cero.");

            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Aeropuerto)
            {
                Aeropuerto aeropuerto = (Aeropuerto)obj;
                sonIguales = _codigoIATA.Equals(aeropuerto._codigoIATA);
            }
            return sonIguales;
        }

    }
}

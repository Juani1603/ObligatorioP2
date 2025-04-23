namespace LogicaNegocio
{
    public class Avion
    {
        private string _fabricante;
        private string _modelo;
        private int _cantidadAsientos;
        private double _alcanceKm;
        private double _costoOperacionKm;

        public string Fabricante
        {
            get { return _fabricante; }
        }

        public string Modelo
        {
            get { return _modelo; }
        }
        public int CantidadAsientos
        {
            get { return _cantidadAsientos; }
        }
        public double CostoOperacionKm
        {
            get { return _costoOperacionKm; }
        }

        public double AlcanceKM
        {
            get { return _alcanceKm; }
        }

        public Avion(string fabricante, string modelo, int cantidadAsientos, double alcanceKm, double costeOperacionKm)
        {
            _fabricante = fabricante;
            _modelo = modelo;
            _cantidadAsientos = cantidadAsientos;
            _alcanceKm = alcanceKm;
            _costoOperacionKm = costeOperacionKm;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_fabricante))
            {
                throw new Exception("El campo del fabricante no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(_modelo))
            {
                throw new Exception("El campo del modelo no puede estar vacío.");
            }
            if (_cantidadAsientos <= 0)
            {
                throw new Exception("La cantidad de asientos debe ser un valor númerico mayor a cero.");
            }
            if (_alcanceKm <= 0)
            {
                throw new Exception("El alcance debe ser mayor a cero.");
            }
            if (_costoOperacionKm <= 0)
            {
                throw new Exception("El costo debe ser mayor a cero.");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false; 
            if (obj != null && obj is Avion)
            {
                Avion avion = (Avion)obj;
                sonIguales = _fabricante.Equals(avion._fabricante);     
            }
            return sonIguales;
        }
    }
}

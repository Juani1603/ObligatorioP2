using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Ruta
    {
        private int _id;
        private static int s_contadorId = 1;
        private Aeropuerto _aeropuertoSalida;
        private Aeropuerto _aeropuertoLlegada;
        private double _distanciaKm;

        public int ID
        {
            get { return _id; }
        }
        public double DistanciaRuta
        {
            get { return _distanciaKm; }
        }

        public Aeropuerto AeropuertoSalida
        {
            get { return _aeropuertoSalida; }
        }

        public Aeropuerto AeropuertoLlegada
        {
            get { return _aeropuertoLlegada; }
        }

        public Ruta(Aeropuerto aeropuertoSalida, Aeropuerto aeropuertoLlegada, double distanciaKm)
        {
            _id = s_contadorId++;
            _aeropuertoSalida = aeropuertoSalida;
            _aeropuertoLlegada = aeropuertoLlegada;
            _distanciaKm = distanciaKm;
        }

        public void Validar()
        {
            if (_aeropuertoSalida == null)
            {
                throw new Exception("El aeropuerto de salida no puede ser nulo.");
            }
            if(_aeropuertoLlegada == null)
            {
                throw new Exception("El aeropuerto de llegada no puede ser nulo.");
            }
            if (_distanciaKm < 0)
            {
                throw new Exception("La distancia debe ser mayor a cero.");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Ruta)
            {
                Ruta ruta = (Ruta)obj;
                sonIguales = _id.Equals(ruta._id);
            }

            return sonIguales;
        }
    }
}

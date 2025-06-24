using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ClientePremium:Cliente
    {
        private int _puntos;

        public int Puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

        public ClientePremium() : base() { }

        public ClientePremium(string correo, string contrasena, string rol, string documento, string nombre, string nacionalidad, int puntos)
            :base(correo, contrasena, rol, documento, nombre, nacionalidad)
        {
            _puntos = puntos;
        }

        public void Validar()
        {
            base.Validar(); 
            if (_puntos <= 0)
            {
                throw new Exception("El campo de puntos debe ser un valor númerico mayor a cero.");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Puntos: {_puntos}";
        }

        public override double ImpuestoPasajePorCliente(Pasaje pasaje)
        {
            double porcentaje = 1;

            if (pasaje.Equipaje.Equals(2))
            {
                porcentaje = 1.05;
            }
            return porcentaje;
        }

        public override string MostrarDatos()
        {
            return _puntos.ToString();
        }

        public override string TipoCliente()
        {
            return "ClientePremium";
        }

        public void ModificarPuntos(int puntos)
        {
            if (puntos == null || puntos == 0)
            {
                throw new Exception("El campo de puntos no puede estar vacío.");
            }
            _puntos = puntos;
        }
    }
}

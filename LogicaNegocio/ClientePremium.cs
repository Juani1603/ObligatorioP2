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
        

        public ClientePremium(string correo, string contrasena, string documento, string nombre, string nacionalidad, int puntos)
            :base(correo, contrasena, documento, nombre, nacionalidad)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Cliente : Usuario, IComparable<Cliente>
    {
        private string _documento;
        private string _nombre;
        private string _nacionalidad;

        public string Documento
        {
            get { return _documento; }  
            set { _documento = value; } 
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Nacionalidad
        {
            get { return _nacionalidad;}
            set {  _nacionalidad = value;}
        }

        public Cliente() : base() { }

        public Cliente(string correo, string contrasena, string rol, string documento, string nombre, string nacionalidad):base(correo, contrasena, rol)
        {
            _documento = documento;
            _nombre = nombre;
            _nacionalidad = nacionalidad;
        }

        public void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_documento))
            {
                throw new Exception("El documento no puede ser nulo.");
            }
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
            if (string.IsNullOrEmpty(_nacionalidad))
            {
                throw new Exception("El campo de nacionalidad no puede estar vacío.");
            }
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Correo: {Correo}, Nacionalidad: {_nacionalidad}, ";
        }

        public override string DefinirRolUsuario()
        {
            return _rol = "Cliente";
        }

        public abstract string MostrarDatos();

        public abstract string TipoCliente();

        public abstract double ImpuestoPasajePorCliente(Pasaje pasaje);

        public int CompareTo(Cliente? other)
        {
           return _documento.CompareTo(other._documento);
        }
    }
}

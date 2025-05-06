using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ClienteOcasional:Cliente
    {
        private bool _elegibleParaRegalo;

        public bool ElegibleParaRegalo
        {
            get { return _elegibleParaRegalo; }
            set { _elegibleParaRegalo = value; }
        }

        public ClienteOcasional(string correo, string contrasena, string documento, string nombre, string nacionalidad)
            : base(correo, contrasena, documento, nombre, nacionalidad)
        {
            //Determina aleatoriamente si el cliente es elegible
            Random random = new Random();
            _elegibleParaRegalo = random.Next(2) == 0;
        }

        public void Validar()
        {
            base.Validar();            
        }

        public override string ToString()
        {
            return base.ToString() + $" ¿Es elegible? {(_elegibleParaRegalo ? "Sí" : "No")}";


        }
    }
}

namespace LogicaNegocio
{
    public class ClienteOcasional : Cliente
    {
        private bool _elegibleParaRegalo;

        public bool ElegibleParaRegalo
        {
            get { return _elegibleParaRegalo; }
            set { _elegibleParaRegalo = value; }
        }
        public ClienteOcasional() : base() { }

        public ClienteOcasional(string correo, string contrasena, string rol, string documento, string nombre, string nacionalidad)
            : base(correo, contrasena, rol, documento, nombre, nacionalidad)
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

        public void CambiarElegibilidad(string elegible)
        {
            switch (elegible)
            {
                case "si":
                    _elegibleParaRegalo = true;
                    break;
                case "no":
                    _elegibleParaRegalo = false;
                    break;
            }
        }

        public override string MostrarDatos()
        {
            return  (_elegibleParaRegalo ? "Sí" : "No");
            
        }

        public override double ImpuestoPasajePorCliente(Pasaje pasaje)
        {
            double porcentaje = 1.10;

            if (pasaje.Equipaje.Equals(2))
            {
                porcentaje = 1.20;
            }
            return porcentaje;
        }
    }
}

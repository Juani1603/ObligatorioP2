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

        public void CambiarElegibilidad(ClienteOcasional cliente, string elegible)
        {
            switch (elegible)
            {
                case "si":
                    cliente.ElegibleParaRegalo = true;
                    break;
                case "no":
                    cliente.ElegibleParaRegalo = false;
                    break;
            }
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

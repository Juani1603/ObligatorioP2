namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        private string _apodo;

        public Administrador(string correo, string contrasena, string apodo) : base(correo, contrasena)
        {
            _apodo = apodo;
        }
        public void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_apodo))
            {
                throw new Exception("El campo de apodo no puede estar vacío.");
            }
        }
        //Método para sumar o restar los puntos según el input del usuario (+ / -)
        public void ModificarPuntos(ClientePremium cliente, int puntos, string inputAdmin)
        {
            switch (inputAdmin)
            {
                case "+":
                    cliente.Puntos += puntos;
                    break;
                case "-":
                    cliente.Puntos -= puntos;
                    break;
            }
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
    }
}

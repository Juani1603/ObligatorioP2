namespace LogicaNegocio
{
    public abstract class Usuario
    {
        private string _correo;
        private string _contrasena;

        public string Correo
        {
            get { return _correo; }
        }

        public Usuario(string correo, string contrasena)
        {
            _correo = correo;
            _contrasena = contrasena;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_correo))
            {
                throw new Exception("El correo no puede estar vacío.");
            }
            if (!_correo.Contains("@"))
            {
                throw new Exception("El correo no tiene un formato válido.");
            }

            if (string.IsNullOrEmpty(_contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }
        }

        public override bool Equals(object? obj)
        {
            bool sonIguales = false;
            if (obj != null && obj is Usuario)
            {
                Usuario usuario = (Usuario)obj;
                sonIguales = _correo.Equals(usuario._correo);
            }
            return sonIguales;
        }
    }
}

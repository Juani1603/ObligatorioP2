namespace LogicaNegocio
{
    public abstract class Usuario
    {
        protected string _correo;
        private string _contrasena;
        protected string _rol;

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public string Rol
        {
            get { return _rol; }
        }

        public Usuario() { }
        public Usuario(string correo, string contrasena, string rol)
        {
            _correo = correo;
            _contrasena = contrasena;
            _rol = rol;
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

            if (string.IsNullOrEmpty(_rol))
            {
                throw new Exception("El rol es obligatorio");
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

        public abstract string DefinirRolUsuario();
    }
}

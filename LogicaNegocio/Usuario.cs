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

            if (_contrasena.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            }

            bool tieneLetra = false;
            bool tieneNumero = false;

            foreach (char caracter in _contrasena)
            {
                if (char.IsLetter(caracter))
                {
                    tieneLetra = true;
                }
                else if (char.IsDigit(caracter))
                {
                    tieneNumero = true;
                }

                if (tieneLetra && tieneNumero)
                {
                    break;
                }
            }

            if (!tieneLetra || !tieneNumero)
            {
                throw new Exception("La contraseña debe contener al menos una letra y un número.");
            }

            if (string.IsNullOrEmpty(_rol))
            {
                throw new Exception("El rol es obligatorio.");
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

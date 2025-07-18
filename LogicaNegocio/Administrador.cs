﻿namespace LogicaNegocio
{
    public class Administrador : Usuario
    {
        private string _apodo;

        public Administrador(string correo, string contrasena, string rol, string apodo) : base(correo, contrasena, rol)
        {
            _apodo = apodo;
        }

        public string Apodo
        {
            get {  return _apodo; }
        }

        public void Validar()
        {
            base.Validar();
            if (string.IsNullOrEmpty(_apodo))
            {
                throw new Exception("El campo de apodo no puede estar vacío.");
            }
        }

        public override string DefinirRolUsuario()
        {
            return _rol = "Admin"; 
        }
    }
}

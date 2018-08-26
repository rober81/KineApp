using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace BLL
{
    public class GestionarSesion
    {
        private BE.Usuario _usuario;
        private static GestionarSesion _instancia = null;

        private GestionarSesion() { }

        public static GestionarSesion getInstance()
        {
            if (_instancia == null)
                _instancia = new GestionarSesion();
            return _instancia;
        }

        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }
        }

        public Boolean iniciarSesion(String paramUser, String paramPass)
        {
            BE.Usuario usr = new BE.Usuario();
            usr.Login = paramUser;
            usr.Password = GestionarEncriptacion.Encriptar(paramPass);
            _usuario = GestionarUsuario.Login(usr);
            return _usuario == null ? false : true;
        }

        public void cerrarSesion()
        {
            this._usuario = null;
        }
    }
}
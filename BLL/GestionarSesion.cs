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
            if (_usuario != null)
            {
                BE.Bitacora bitacora = new Bitacora();
                bitacora.Usuario = this._usuario;
                bitacora.Tabla = "";
                bitacora.Dato = "";
                bitacora.Accion = "Inicia sesion";
                GestionarBitacora.Insertar(bitacora);
                return true;
            } else
            {
                return false;
            }
        }

        public void cerrarSesion()
        {
            BE.Bitacora bitacora = new Bitacora();
            bitacora.Usuario = this._usuario;
            bitacora.Accion = "Cierra sesion";
            bitacora.Tabla = "";
            bitacora.Dato = "";
            GestionarBitacora.Insertar(bitacora);
            this._usuario = null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GestionarUsuario
    {
        public static BE.Usuario Login (BE.Usuario usr)
        {
            BE.Usuario logueado = null;
            String usrHard = "rober";
            String passHard = GestionarEncriptacion.Encriptar("rober");
            if (usr.Login.Equals(usrHard) && usr.Password.Equals(passHard))
            {
                logueado = new BE.Usuario();
                logueado.Nombre = "Roberto";
                logueado.Apellido = "Piombi";
                logueado.Correo = "robertopiombi@gmail.com";
                logueado.Login = usr.Login;
                logueado.Password = usr.Password;
            }
            return logueado;
        }
    }
}
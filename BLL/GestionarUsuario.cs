using System.Collections.Generic;

namespace BLL
{
    public class GestionarUsuario
    {
        public static BE.Usuario Login(BE.Usuario usr)
        {
            return DAL.UsuarioMapper.Login(usr);
        }

        public static int Insertar(BE.Usuario usr)
        {
            usr.Password = GestionarEncriptacion.Encriptar(usr.Password);
            return DAL.UsuarioMapper.Insertar(usr);
        }

        public static int Modificar(BE.Usuario usr)
        {
            usr.Password = GestionarEncriptacion.Encriptar(usr.Password);
            return DAL.UsuarioMapper.Modificar(usr);
        }

        public static List<BE.Usuario> Listar()
        {
            return DAL.UsuarioMapper.Listar();
        }
    }
}
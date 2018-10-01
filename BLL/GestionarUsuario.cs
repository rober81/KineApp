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
            return DAL.UsuarioMapper.Login(usr);
        }

    }
}
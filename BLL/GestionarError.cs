using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BLL
{
    public class GestionarError
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "log.txt";

        public static void loguear(String mensaje)
        {
            BE.Usuario usuario = GestionarSesion.getInstance().Usuario;
            string fecha = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");

            string log = "Usuario: " + usuario.ToString() + " " + fecha + " = " + mensaje + Environment.NewLine;
            File.AppendAllText(path, log);
        }
    }
}
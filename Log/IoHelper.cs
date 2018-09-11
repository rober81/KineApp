using System;
using System.IO;
using Newtonsoft.Json;

namespace Util
{
    public class IoHelper
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "log.txt";

        public static void Log(String mensaje)
        {
            File.AppendAllText(path, mensaje);
        }

        static string Serializar (Object objeto)
        {
            string resultado = JsonConvert.SerializeObject(objeto);
            return resultado;
        }
        static T DesSerializar<T>(string mensaje)
        {
            T resultado = JsonConvert.DeserializeObject<T>(mensaje);
            return resultado;
        }
    }
}

using System;
using System.IO;
using Newtonsoft.Json;

namespace Util
{
    public class IoHelper
    {
        static string raizApp = AppDomain.CurrentDomain.BaseDirectory + @"\";
        static string logArchivo = raizApp + "log.txt";
        static string configuracionArchivo = raizApp + "configuracion.json";

        public static void Log(String mensaje)
        {
            File.AppendAllText(logArchivo, mensaje);
        }

        public static string Serializar (Object objeto)
        {
            string resultado = JsonConvert.SerializeObject(objeto);
            return resultado;
        }
        public static T DesSerializar<T>(string mensaje)
        {
            T resultado = JsonConvert.DeserializeObject<T>(mensaje);
            return resultado;
        }

        public static void CrearConfiguracion()
        {
            Configuracion config = new Configuracion();
            config.aplicacionDB = "KineApp";
            config.bitacoraDB = "KineAppBitacora";
            config.servidor = "SQLEXPRESS";
            File.WriteAllText(configuracionArchivo, JsonConvert.SerializeObject(config));
        }

        public static Configuracion LeerConfiguracion()
        {
            Configuracion config = null;
            
            try
            {
                if (! File.Exists(configuracionArchivo))
                {
                    CrearConfiguracion(); //Configuracion por defecto
                }
                using (StreamReader file = File.OpenText(configuracionArchivo))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    config = (Configuracion)serializer.Deserialize(file, typeof(Configuracion));
                }
            }
            catch (Exception)
            {
                Log("Error al leer Configuracion.json");
            }
            return config;
        }


    }
}

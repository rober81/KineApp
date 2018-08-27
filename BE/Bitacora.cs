using System;
namespace BE
{
    public class Bitacora
    {
        public Bitacora()
        {
            Fecha = DateTime.Now;
        }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public string Tabla { get; set; }
        public string Accion { get; set; }
        public string Dato { get; set; }
    }
}
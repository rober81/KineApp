using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace BE
{
    public class Idioma
    {
        public Idioma(string nombre)
        {
            this.Nombre = nombre;
        }
        public String Nombre { get; set; }
        public Dictionary<string, string> Detalle { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
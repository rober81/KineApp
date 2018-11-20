using System;
using System.Collections.Generic;

namespace BE
{
    public class Idioma
    {
        public Idioma(string nombre)
        {
            this.Nombre = nombre;
        }
        public string Nombre { get; set; }
        public Dictionary<string, string> Detalle { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
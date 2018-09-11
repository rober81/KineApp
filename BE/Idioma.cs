using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Idioma
    {
        public String Nombre { get; set; }
        public List<IdiomaDetalle> Detalle { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
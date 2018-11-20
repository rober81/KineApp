using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Perfiles
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Padre { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nombre;
        }
    }
}
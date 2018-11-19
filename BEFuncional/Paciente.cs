using System;
using BE;
using System.Globalization;

namespace BEFuncional
{
    public class Paciente : BE.Persona, iDigitoVerificador
    {
        public DateTime FechaNacimiento { get; set; }

        public int DVH { get; set; }

        public override string ToString()
        {
            return Dni + " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Nombre) + " " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Apellido);
        }

        public string getDVH()
        {
            return Nombre + Apellido + Dni;
        }

        public string getID()
        {
            return Dni.ToString();
        }
    }
}

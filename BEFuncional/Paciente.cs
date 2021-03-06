﻿using System;
using BE;
using System.Globalization;
using System.Xml.Serialization;

namespace BEFuncional
{
    public class Paciente : BE.Persona, iDigitoVerificador
    {
        public DateTime FechaNacimiento { get; set; }

        [XmlIgnore]
        public int DVH { get; set; }

        public override string ToString()
        {
            return Dni + " " + Nombre + " " + Apellido;
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

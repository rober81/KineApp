﻿using System;
using BE;

namespace BEFuncional
{
    public class Paciente : BE.Persona, iDigitoVerificador
    {
        public DateTime FechaNacimiento { get; set; }

        public int DVH { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Apellido;
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

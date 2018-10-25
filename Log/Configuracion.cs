﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Configuracion
    {
        public string servidor { get; set; }
        public string aplicacionDB { get; set; }
        public string bitacoraDB { get; set; }
        private static Configuracion instancia = null;

        public static Configuracion getInstance()
        {
            if (instancia == null)
            {
                instancia = IoHelper.LeerConfiguracion();
            }
            return instancia;
        }

        internal Configuracion()
        {

        }
    }
}
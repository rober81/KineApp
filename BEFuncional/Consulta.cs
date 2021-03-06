﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BEFuncional
{
    [XmlRoot("Consulta")]
    public class Consulta : BE.iDigitoVerificador
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Resumen { get; set; }

        [XmlArray("ListaDetalle"), XmlArrayItem(typeof(ConsultaDetalle), ElementName = "Detalle")]
        public List<ConsultaDetalle> Detalle { get; set; }

        [XmlIgnore]
        public int DVH { get; set; }

        public string getID()
        {
            return Id.ToString();
        }

        public string getDVH()
        {
            return Paciente.Dni + Fecha.ToString("dd/MM/yyyy") + Resumen;
        }

        public override string ToString()
        {
            return Id + " " + Paciente.ToString();
        }
    }
}

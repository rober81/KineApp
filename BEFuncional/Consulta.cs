using System;
using System.Collections.Generic;

namespace BEFuncional
{
    public class Consulta
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Resumen { get; set; }
        public List<ConsultaDetalle> Detalle { get; set; }
    }
}

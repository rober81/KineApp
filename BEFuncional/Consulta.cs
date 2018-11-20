using System;
using System.Collections.Generic;

namespace BEFuncional
{
    public class Consulta : BE.iDigitoVerificador
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Resumen { get; set; }
        public List<ConsultaDetalle> Detalle { get; set; }

        public int DVH { get; set; }

        public string getID()
        {
            return Id.ToString();
        }

        public string getDVH()
        {
            return Id + Paciente.Dni + Fecha.ToString("dd/MM/yyyy") + Resumen;
        }

        public override string ToString()
        {
            return Id + " " + Paciente.ToString();
        }
    }
}

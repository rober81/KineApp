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
        public Patologia Patologia { get; set; }
        public List<Entrenamiento> Entrenamientos { get; set; }
        public List<Tratamiento> Tratamientos { get; set; }
        public List<string> Resultados { get; set; }
    }
}

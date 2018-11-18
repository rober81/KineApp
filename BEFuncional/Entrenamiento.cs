using System.Collections.Generic;


namespace BEFuncional
{
    public class Entrenamiento : DatoBase
    {
        public List<Ejercicio> ListaEjercicios { get; set; }

        public Entrenamiento()
        {
            ListaEjercicios = new List<Ejercicio>();
        }
    }
}

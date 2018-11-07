using System.Collections.Generic;


namespace BEFuncional
{
    public class Entrenamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Ejercicio> ListaEjercicios { get; set; }
    }
}

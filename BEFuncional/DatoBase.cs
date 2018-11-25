namespace BEFuncional
{
    public class DatoBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string PalabrasClave { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nombre;
        }
    }
}
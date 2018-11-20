namespace BEFuncional
{
    public class ConsultaDetalle : BE.iDigitoVerificador
    {
        public DatoBase Item { get; set; }
        public string Observaciones { get; set; }
        public string Resultado { get; set; }

        public override string ToString()
        {
            return Item.ToString();
        }

        public int DVH { get; set; }

        public string getID()
        {
            return Item.Id.ToString();
        }

        public string getDVH()
        {
            return Item.Id + Observaciones + Resultado;
        }
    }
}
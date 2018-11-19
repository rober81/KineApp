using System.Collections.Generic;

namespace BEFuncional
{
    public class ConsultaDetalle
    {
        public DatoBase Item { get; set; }
        public string Observaciones { get; set; }
        public string Resultado { get; set; }

        public override string ToString()
        {
            return Item.ToString();
        }
    }
}
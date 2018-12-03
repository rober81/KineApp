using System;
using System.Xml.Serialization;

namespace BEFuncional
{
    [XmlInclude(typeof(Patologia))]
    [XmlInclude(typeof(Tratamiento))]
    [XmlInclude(typeof(Entrenamiento))]
    [XmlInclude(typeof(Ejercicio))]

    public class ConsultaDetalle : BE.iDigitoVerificador
    {
        public DatoBase Item { get; set; }
        public string Observaciones { get; set; }
        public string Resultado { get; set; }

        public override string ToString()
        {
            return Item.ToString();
        }

        [XmlIgnore]
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
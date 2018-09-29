using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionarIdioma
    {
        private BE.Idioma idiomaSeleccionado;
        private static GestionarIdioma _instancia = null;

        private GestionarIdioma() { }

        public static GestionarIdioma getInstance()
        {
            if (_instancia == null)
                _instancia = new GestionarIdioma();
            return _instancia;
        }

        public List<BE.Idioma> Listar()
        {
            return DAL.IdiomaMapper.Listar();
        }

        public void CambiarIdioma(BE.Idioma unIdioma)
        {
            DAL.IdiomaMapper.CargarDetalle(unIdioma);
            this.idiomaSeleccionado = unIdioma;
        }

        public string getTexto (string clave)
        {
            string resultado = null;
            try
            {
                resultado = idiomaSeleccionado.Detalle[clave];
            }
            catch (KeyNotFoundException)
            {
                resultado = "Falta Traduccion";
                Util.Log.Error("Falta traducir idioma:" + idiomaSeleccionado.Nombre + " clave:" + clave);
            }
            return resultado;
        }

    }
}

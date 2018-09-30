using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionarIdioma
    {
        public BE.Idioma IdiomaSeleccionado { get; private set; }
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

        public void Cargar(BE.Idioma unIdioma)
        {
            DAL.IdiomaMapper.CargarDetalle(unIdioma);
        }

        public void CambiarIdioma(BE.Idioma unIdioma)
        {
            Cargar(unIdioma);
            IdiomaSeleccionado = unIdioma;
        }

        public string getTexto (string clave)
        {
            string resultado = null;
            try
            {
                resultado = IdiomaSeleccionado.Detalle[clave];
            }
            catch (KeyNotFoundException)
            {
                resultado = "Falta Traduccion";
                Util.Log.Error("Falta traducir idioma:" + IdiomaSeleccionado.Nombre + " clave:" + clave);
            }
            return resultado;
        }

        public int insertarDetalle(BE.IdiomaDetalle unDetalle)
        {
            int respuesta = DAL.IdiomaMapper.Insertar(unDetalle);
            return respuesta;
        }

    }
}

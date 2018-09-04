using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class GestionarIdioma
    {
        private Dictionary<string, BE.IdiomaDetalle> idiomaSeleccionado;
        public Dictionary<string, BE.IdiomaDetalle> getIdiomaSeleccionado()
        {
            return idiomaSeleccionado;
        }

        public static List<BE.Idioma> Listar()
        {
            return DAL.IdiomaMapper.Listar();
        }
        private void CargarIdioma(BE.Idioma unIdioma)
        {
            DAL.IdiomaMapper.CargarDetalle(unIdioma);
        }

        public void CambiarIdioma(BE.Idioma unIdioma)
        {
            this.idiomaSeleccionado = new Dictionary<string, BE.IdiomaDetalle>();
            CargarIdioma(unIdioma);
            foreach (BE.IdiomaDetalle item in unIdioma.Detalle)
            {
                idiomaSeleccionado.Add(item.Clave, item);
            }

        }

    }
}

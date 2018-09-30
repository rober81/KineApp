using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class IdiomaMapper
    {
        public static List<BE.Idioma> Listar()
        {
            List<BE.Idioma> lista = new List<BE.Idioma>();
            DataTable tabla = SqlHelper.getInstance().leer("Idioma_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                lista.Add(new BE.Idioma(item["nombre"].ToString()));
            }
            return lista;
        }

        public static void CargarDetalle(BE.Idioma unIdioma)
        {
            Dictionary<string, string> lista = new Dictionary<string, string>(); ;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@idioma", unIdioma.Nombre);
            DataTable tabla = SqlHelper.getInstance().leer("IdiomaDetalle_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                lista.Add(item["clave"].ToString(), item["texto"].ToString());
            }
            unIdioma.Detalle = lista;
        }

        public static int Insertar(BE.IdiomaDetalle detalle)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@idioma", detalle.Idioma);
            parametros[1] = new SqlParameter("@clave", detalle.Clave);
            parametros[2] = new SqlParameter("@texto", detalle.Texto);

            return SqlHelper.getInstance().escribir("IdiomaDetalle_alta", parametros);
        }
    }
}
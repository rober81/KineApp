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
            BE.Idioma obj = null;
            List<BE.Idioma> lista = new List<BE.Idioma>();
            DataTable tabla = SqlHelper.getInstance().leer("Idioma_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new BE.Idioma();
                obj.Nombre = item["nombre"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static void CargarDetalle(BE.Idioma unIdioma)
        {
            BE.IdiomaDetalle obj = null;
            List<BE.IdiomaDetalle> lista = new List<BE.IdiomaDetalle>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@idioma", unIdioma.Nombre);
            DataTable tabla = SqlHelper.getInstance().leer("IdiomaDetalle_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new BE.IdiomaDetalle();
                obj.Clave = item["clave"].ToString();
                obj.Texto = item["texto"].ToString();
                lista.Add(obj);
            }
            unIdioma.Detalle = lista;
        }

        // public static int Insertar(BE.Bitacora bitacora)
        //{
        //SqlParameter[] parametros = new SqlParameter[6];
        //parametros[0] = new SqlParameter("@usuario", bitacora.Usuario.ToString());
        //parametros[1] = new SqlParameter("@fecha", bitacora.Fecha);
        //parametros[2] = new SqlParameter("@tabla", bitacora.Tabla);
        //parametros[3] = new SqlParameter("@dato", bitacora.Dato);
        //parametros[4] = new SqlParameter("@accion", bitacora.Accion);
        //parametros[5] = new SqlParameter("@dvh", "dvh");
        //return SqlHelper.getInstanceBitacora().escribir("Bitacora_alta", parametros);
        //}
    }
}
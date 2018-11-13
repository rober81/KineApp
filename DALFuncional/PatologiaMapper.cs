using System.Collections.Generic;
using BEFuncional;
using System.Data;
using DAL;
using System.Data.SqlClient;

namespace DALFuncional
{
    public class PatologiaMapper
    {
        public static string Tabla = "Patologia";

        public static List<Patologia> Listar()
        {
            Patologia obj = null;
            List<Patologia> lista = new List<Patologia>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Patologia();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static Patologia Buscar(Patologia param)
        {
            Patologia obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Patologia();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
            }
            return obj;
        }

        public static int Insertar(Patologia param)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(Ejercicio param)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
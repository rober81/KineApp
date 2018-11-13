using BEFuncional;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALFuncional
{
    public class TratamientoMapper
    {
        public static string Tabla = "Tratamiento";

        public static List<Tratamiento> Listar()
        {
            Tratamiento obj = null;
            List<Tratamiento> lista = new List<Tratamiento>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Tratamiento();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static Tratamiento Buscar(Tratamiento param)
        {
            Tratamiento obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Tratamiento();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
            }
            return obj;
        }

        public static int Insertar(Tratamiento param)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(Tratamiento param)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
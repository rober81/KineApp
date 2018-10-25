using BEFuncional;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALFuncional
{
    public class EjercicioMapper
    {
        public static string Tabla = "Ejercicio";

        public static List<Ejercicio> Listar()
        {
            Ejercicio obj = null;
            List<Ejercicio> lista = new List<Ejercicio>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Ejercicio();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                obj.Cantidad = item["cantidad"].ToString();
                obj.Repeticiones = item["repeticiones"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int Insertar(Ejercicio param)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[2] = new SqlParameter("@cantidad", param.Cantidad);
            parametros[3] = new SqlParameter("@repeticiones", param.Repeticiones);
            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(Ejercicio param)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[3] = new SqlParameter("@cantidad", param.Cantidad);
            parametros[4] = new SqlParameter("@repeticiones", param.Repeticiones);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
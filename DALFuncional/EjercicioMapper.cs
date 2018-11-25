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
        public static string Tabla2 = "EntrenamientoEjercicio";

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
                obj.PalabrasClave = item["palabras"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static Ejercicio Buscar(Ejercicio param)
        {
            Ejercicio obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Ejercicio();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                obj.Cantidad = item["cantidad"].ToString();
                obj.Repeticiones = item["repeticiones"].ToString();
                obj.PalabrasClave = item["palabras"].ToString();
            }
            return obj;
        }

        public static int Insertar(Ejercicio param)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[2] = new SqlParameter("@cantidad", param.Cantidad);
            parametros[3] = new SqlParameter("@repeticiones", param.Repeticiones);
            parametros[4] = new SqlParameter("@palabras", param.PalabrasClave);
            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(Ejercicio param)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[3] = new SqlParameter("@cantidad", param.Cantidad);
            parametros[4] = new SqlParameter("@repeticiones", param.Repeticiones);
            parametros[5] = new SqlParameter("@palabras", param.PalabrasClave);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }

        public static int InsertarEjercicio(Entrenamiento entrenamiento, Ejercicio ejercicio)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id_entrenamiento", entrenamiento.Id);
            parametros[1] = new SqlParameter("@id_ejercicio", ejercicio.Id);
            parametros[2] = new SqlParameter("@observaciones", ejercicio.Observaciones);
            return SqlHelper.getInstance().escribir(Tabla2 + "_alta", parametros);
        }

        public static int BorrarEjercicio(Entrenamiento param)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_entrenamiento", param.Id);
            return SqlHelper.getInstance().escribir(Tabla2 + "_baja", parametros);
        }

        public static List<Ejercicio> BuscarEjercicio(Entrenamiento param)
        {
            Ejercicio obj = null;
            List<Ejercicio> lista = new List<Ejercicio>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_entrenamiento", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Ejercicio();
                obj.Id = int.Parse(item["id_ejercicio"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                obj.Cantidad = item["cantidad"].ToString();
                obj.Repeticiones = item["repeticiones"].ToString();
                obj.Observaciones = item["observaciones"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
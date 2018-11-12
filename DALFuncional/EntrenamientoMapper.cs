using BEFuncional;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALFuncional
{
    public class EntrenamientoMapper
    {
        public static string Tabla = "Entrenamiento";
        public static string Tabla2 = "EntrenamientoEjercicio";

        public static List<Entrenamiento> Listar()
        {
            Entrenamiento obj = null;
            List<Entrenamiento> lista = new List<Entrenamiento>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Entrenamiento();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                obj.ListaEjercicios = buscarEjercicios(obj.Id);
                lista.Add(obj);
            }
            return lista;
        }

        public static int Insertar(Entrenamiento param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[2] = new SqlParameter("@id",0);
            parametros[2].Direction = ParameterDirection.Output;
            SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
            int id = int.Parse(parametros[2].Value.ToString());
            return id;
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

        private static List<Ejercicio> buscarEjercicios(int id)
        {
            Ejercicio obj = null;
            List<Ejercicio> lista = new List<Ejercicio>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_entrenamiento", id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                int id_ejercicio = int.Parse(item["id_ejercicio"].ToString());
                string obs = item["observaciones"].ToString();
                obj = EjercicioMapper.Buscar(id_ejercicio);
                obj.Observaciones = obs;
                lista.Add(obj);
            }
            return lista;
        }

        public static int Modificar(Entrenamiento param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
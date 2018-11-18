using BEFuncional;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DALFuncional
{
    public class DatoBaseMapper<T> where T : DatoBase, new()
    {
        private string Tabla;

        public DatoBaseMapper(string param)
        {
            Tabla = param;
        }

        public List<T> Listar()
        {
            T obj = null;
            List<T> lista = new List<T>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new T();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public T Buscar(T param)
        {
            T obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new T();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Descripcion = item["descripcion"].ToString();
            }
            return obj;
        }

        public int Insertar(T param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@nombre", param.Nombre);
            parametros[1] = new SqlParameter("@descripcion", param.Descripcion);
            parametros[2] = new SqlParameter("@id", 0);
            parametros[2].Direction = ParameterDirection.Output;
            SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
            int id = int.Parse(parametros[2].Value.ToString());
            return id;
        }

        public int Modificar(T param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id", param.Id);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@descripcion", param.Descripcion);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PerfilMapper
    {
        public static string Tabla = "Perfil";
        public static string Tabla2 = "UsuarioPerfil";

        public static List<BE.Perfiles> ListarPerfiles()
        {
            List<BE.Perfiles> lista = new List<BE.Perfiles>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                BE.Perfiles obj = new BE.Perfiles();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Padre = int.Parse(item["padre"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static List<int> ListarUsuarioPerfil(BE.Usuario param)
        {
            List<int> lista = new List<int>(); ;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@usuario", param.Login);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                lista.Add(int.Parse(item["perfil"].ToString()));
            }
            return lista;
        }
    }
}
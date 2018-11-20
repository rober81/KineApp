using BE;
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

        public static List<Perfiles> ListarPerfiles()
        {
            List<Perfiles> lista = new List<Perfiles>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                Perfiles obj = new Perfiles();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Nombre = item["nombre"].ToString();
                if (! string.IsNullOrEmpty(item["padre"].ToString()))
                    obj.Padre = int.Parse(item["padre"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static List<Perfiles> ListarUsuarioPerfil(Usuario param)
        {
            List<Perfiles> lista = new List<Perfiles>(); ;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@usuario", param.Login);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                Perfiles per = new Perfiles();
                per.Id = int.Parse(item["perfil"].ToString());
                per.Nombre = item["nombre"].ToString();
                //per.Padre = int.Parse(item["padre"].ToString());
                lista.Add(per);
            }
            return lista;
        }

        public static int InsertarUsuarioPerfil(Usuario param, Perfiles perfil)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@usuario", param.Dni);
            parametros[1] = new SqlParameter("@perfil", perfil.Id);
            int res = SqlHelper.getInstance().escribir(Tabla2 + "_alta", parametros);
            return res;
        }

        public static int BorrarUsuarioPerfil(Usuario param, Perfiles perfil)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@usuario", param.Dni);
            parametros[1] = new SqlParameter("@perfil", perfil.Id);
            return SqlHelper.getInstance().escribir(Tabla + "_borrar", parametros);
        }
    }
}
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace DAL
{
    public class UsuarioMapper
    {
        public static string Tabla = "Usuario";

        public static BE.Usuario Login(BE.Usuario unUsuario)
        {
            BE.Usuario obj = null;
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@usuario", unUsuario.Login);
            parametros[1] = new SqlParameter("@pass", unUsuario.Password);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_login", parametros);
            foreach (DataRow item in tabla.Rows) {
                obj = new BE.Usuario();
                obj.Login = item["usuario"].ToString();
                obj.Password = item["password"].ToString();
                obj.Nombre = item["nombre"].ToString();
                obj.Apellido = item["apellido"].ToString();
                obj.Correo = item["correo"].ToString();
                obj.Edad = int.Parse(item["edad"].ToString());
                obj.Dni = int.Parse(item["dni"].ToString());
                obj.DVH = int.Parse(item["Dvh"].ToString());
            }
            return obj;
        }

        public static List<BE.Usuario> Listar()
        {
            BE.Usuario obj = null;
            List<BE.Usuario> lista = new List<BE.Usuario>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new BE.Usuario();
                obj.Login = item["usuario"].ToString();
                obj.Password = item["password"].ToString();
                obj.Nombre = item["nombre"].ToString();
                obj.Apellido = item["apellido"].ToString();
                obj.Correo = item["correo"].ToString();
                obj.Edad = int.Parse(item["edad"].ToString());
                obj.Dni = int.Parse(item["dni"].ToString());
                obj.DVH = int.Parse(item["Dvh"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static int Insertar(BE.Usuario param)
        {
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@usuario", param.Login);
            parametros[1] = new SqlParameter("@pass", param.Password);
            parametros[2] = new SqlParameter("@nombre", param.Nombre);
            parametros[3] = new SqlParameter("@apellido", param.Apellido);
            parametros[4] = new SqlParameter("@correo", param.Correo);
            parametros[5] = new SqlParameter("@edad", param.Edad);
            parametros[6] = new SqlParameter("@dni", param.Dni);
            parametros[7] = new SqlParameter("@dvh", param.DVH);

            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(BE.Usuario param)
        {
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@usuario", param.Login);
            parametros[1] = new SqlParameter("@pass", param.Password);
            parametros[2] = new SqlParameter("@nombre", param.Nombre);
            parametros[3] = new SqlParameter("@apellido", param.Apellido);
            parametros[4] = new SqlParameter("@correo", param.Correo);
            parametros[5] = new SqlParameter("@edad", param.Edad);
            parametros[6] = new SqlParameter("@dni", param.Dni);
            parametros[7] = new SqlParameter("@dvh", param.DVH);

            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }

        public static int CalcularDVH()
        {
            int cantidad = 0;
            foreach (BE.Usuario item in Listar())
            {
                item.DVH = Util.DigitoVerificador.CalcularDV(item.getDVH());
                Modificar(item);
                cantidad++;
            }
            return cantidad;
        }

        public static int CalcularDVV()
        {
            string cadena = string.Empty;
            foreach (BE.Usuario item in Listar())
            {
                cadena += item.DVH;
            }
            return Util.DigitoVerificador.CalcularDV(cadena);
        }
    }
}
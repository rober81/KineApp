using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BEFuncional;
using DAL;
using System;

namespace DALFuncional
{
    public class PacienteMapper
    {
        public static string Tabla = "Paciente";

        public static List<Paciente> Listar()
        {
            Paciente obj = null;
            List<Paciente> lista = new List<Paciente>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Paciente();
                obj.Dni = int.Parse(item["dni"].ToString());
                obj.Nombre = item["nombre"].ToString();
                obj.Apellido = item["apellido"].ToString();
                obj.FechaNacimiento = DateTime.Parse(item["fechaNacimiento"].ToString());
                obj.DVH = int.Parse(item["Dvh"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static void Buscar(Paciente param)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@dni", param.Dni);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                param.Dni = int.Parse(item["dni"].ToString());
                param.Nombre = item["nombre"].ToString();
                param.Apellido = item["apellido"].ToString();
                param.FechaNacimiento = DateTime.Parse(item["fechaNacimiento"].ToString());
                param.DVH = int.Parse(item["Dvh"].ToString());
            }
        }

        public static int Insertar(Paciente param)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@dni", param.Dni);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@apellido", param.Apellido);
            parametros[3] = new SqlParameter("@fechaNacimiento", param.FechaNacimiento);
            parametros[4] = new SqlParameter("@dvh", param.DVH);

            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(Paciente param)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@dni", param.Dni);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@apellido", param.Apellido);
            parametros[3] = new SqlParameter("@fechaNacimiento", param.FechaNacimiento);
            parametros[4] = new SqlParameter("@dvh", param.DVH);

            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
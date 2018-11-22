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
                obj.DVH = int.Parse(item["DVH"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static Paciente Buscar(Paciente param)
        {
            Paciente buscado = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@dni", param.Dni);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                buscado = new Paciente();
                buscado.Dni = int.Parse(item["dni"].ToString());
                buscado.Nombre = item["nombre"].ToString();
                buscado.Apellido = item["apellido"].ToString();
                buscado.FechaNacimiento = DateTime.Parse(item["fechaNacimiento"].ToString());
                buscado.DVH = int.Parse(item["Dvh"].ToString());
            }
            return buscado;
        }

        private static SqlParameter[] crearParametros(Paciente param)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@dni", param.Dni);
            parametros[1] = new SqlParameter("@nombre", param.Nombre);
            parametros[2] = new SqlParameter("@apellido", param.Apellido);
            parametros[3] = new SqlParameter("@fecha", param.FechaNacimiento);
            parametros[4] = new SqlParameter("@dvh", Util.DigitoVerificador.CalcularDV(param.getDVH()));
            return parametros;
        }

        public static int Insertar(Paciente param)
        {
             return SqlHelper.getInstance().escribir(Tabla + "_alta", crearParametros(param));
        }

        public static int Modificar(Paciente param)
        {
             return SqlHelper.getInstance().escribir(Tabla + "_modificar", crearParametros(param));
        }
    }
}
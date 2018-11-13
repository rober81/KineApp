using BEFuncional;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALFuncional
{
    public class ConsultaMapper
    {
        public static string Tabla = "Consulta";
        public static string Tabla2 = "ConsultaDetalle";

        public static List<Consulta> Listar()
        {
            Consulta obj = null;
            List<Consulta> lista = new List<Consulta>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Consulta();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Fecha = DateTime.Parse(item["fecha"].ToString());
                obj.Resumen = item["resumen"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static Consulta Buscar(Consulta param)
        {
            Consulta obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Consulta();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Fecha = DateTime.Parse(item["fecha"].ToString());
                obj.Resumen = item["resumen"].ToString();
            }
            return obj;
        }

        public static int Insertar(Consulta param)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@paciente", param.Paciente.Dni);
            parametros[1] = new SqlParameter("@fecha", param.Fecha);
            parametros[2] = new SqlParameter("@resumen", param.Resumen);
            parametros[3] = new SqlParameter("@id", 0);
            parametros[3].Direction = ParameterDirection.Output;
            SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
            return int.Parse(parametros[3].Value.ToString());
        }

        public static int Modificar(Consulta param)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@paciente", param.Paciente.Dni);
            parametros[1] = new SqlParameter("@fecha", param.Fecha);
            parametros[2] = new SqlParameter("@resumen", param.Resumen);
            parametros[3] = new SqlParameter("@id", 0);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }

        public static int InsertarDetalleEntrenamiento(Consulta con, Entrenamiento ent)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id_consulta", con.Id);
            parametros[1] = new SqlParameter("@id_patologia", con.Patologia.Id);
            parametros[2] = new SqlParameter("@id_entrenamiento", ent.Id);
            parametros[3] = new SqlParameter("@id_tratamiento", 0);
            parametros[4] = new SqlParameter("@resultado", "");
            return SqlHelper.getInstance().escribir(Tabla2 + "_alta", parametros);
        }

        public static int InsertarDetalleTratamiento(Consulta con, Tratamiento trat)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id_consulta", con.Id);
            parametros[1] = new SqlParameter("@id_patologia", con.Patologia.Id);
            parametros[2] = new SqlParameter("@id_entrenamiento", 0);
            parametros[3] = new SqlParameter("@id_tratamiento", trat.Id);
            parametros[4] = new SqlParameter("@resultado", "");
            return SqlHelper.getInstance().escribir(Tabla2 + "_alta", parametros);
        }

        //public static int BorrarEjercicio(Entrenamiento param)
        //{
        //    SqlParameter[] parametros = new SqlParameter[1];
        //    parametros[0] = new SqlParameter("@id_entrenamiento", param.Id);
        //    return SqlHelper.getInstance().escribir(Tabla2 + "_baja", parametros);
        //}

        public static List<Ejercicio> BuscarDetalle(Consulta param)
        {
            Ejercicio obj = null;
            List<Ejercicio> lista = new List<Ejercicio>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_consulta", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                int consulta = int.Parse(item["id_consulta"].ToString());
                int patologia = int.Parse(item["id_patologia"].ToString());
                int entrenamiento = int.Parse(item["id_entrenamiento"].ToString());
                int tratamiento = int.Parse(item["id_tratamiento"].ToString());
                string resultado = item["resultado"].ToString();
                lista.Add(obj);
            }
            return lista;
        }
    }
}
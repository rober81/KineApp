using BEFuncional;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                obj.Paciente = new Paciente() { Dni = int.Parse(item["paciente"].ToString()) };
                obj.Fecha = DateTime.Parse(item["fecha"].ToString());
                obj.Resumen = item["resumen"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static Consulta Buscar(int param)
        {
            Consulta obj = null;
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", param);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Consulta();
                obj.Id = int.Parse(item["id"].ToString());
                obj.Paciente = new Paciente() { Dni = int.Parse(item["paciente"].ToString()) };
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

        public static int InsertarDetalle(int id, ConsultaDetalle detalle)
        {
            DatoBase item = detalle.Item;
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@id_consulta", id);
            parametros[1] = new SqlParameter("@id_ejercicio", (item is Ejercicio) ? item.Id:0);
            parametros[2] = new SqlParameter("@id_entrenamiento", (item is Entrenamiento) ? item.Id : 0);
            parametros[3] = new SqlParameter("@id_tratamiento", (item is Tratamiento) ? item.Id : 0);
            parametros[4] = new SqlParameter("@id_patologia", (item is Patologia) ? item.Id : 0);
            parametros[5] = new SqlParameter("@resultado", detalle.Resultado);
            parametros[6] = new SqlParameter("@observaciones", detalle.Observaciones);
            return SqlHelper.getInstance().escribir(Tabla2 + "_alta", parametros);
        }

        public static List<ConsultaDetalle> BuscarDetalle(Consulta param)
        {
            ConsultaDetalle detalle = null;
            List<ConsultaDetalle> lista = new List<ConsultaDetalle>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_consulta", param.Id);
            DataTable tabla = SqlHelper.getInstance().leer(Tabla2 + "_leer", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                int ejercicio = int.Parse(item["id_ejercicio"].ToString());
                int entrenamiento = int.Parse(item["id_entrenamiento"].ToString());
                int tratamiento = int.Parse(item["id_tratamiento"].ToString());
                int patologia = int.Parse(item["id_patologia"].ToString());

                detalle = new ConsultaDetalle();
                if (ejercicio != 0)
                    detalle.Item = new Ejercicio() { Id = ejercicio };
                if (entrenamiento != 0)
                    detalle.Item = new Entrenamiento() { Id = entrenamiento };
                if (tratamiento != 0)
                    detalle.Item = new Tratamiento() { Id = tratamiento };
                if (patologia != 0)
                    detalle.Item = new Patologia() { Id = patologia };

                detalle.Resultado = item["resultado"].ToString();
                detalle.Observaciones = item["observaciones"].ToString();
                lista.Add(detalle);
            }
            return lista;
        }

        public static int BorrarDetalle(Consulta param)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id_consulta", param.Id);
            return SqlHelper.getInstance().escribir(Tabla2 + "_borrar", parametros);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DigitoVerificadorMapper
    {
        public static string Tabla = "Digitoverificador";

        public static List<BE.DigitoVerificador> Listar()
        {
            List<BE.DigitoVerificador> lista = new List<BE.DigitoVerificador>();
            DataTable tabla = SqlHelper.getInstance().leer(Tabla + "_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                BE.DigitoVerificador obj = new BE.DigitoVerificador();
                obj.Tabla = item["tabla"].ToString();
                obj.DVH = int.Parse(item["DVH"].ToString());
                obj.DVV = int.Parse(item["DVV"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static int Insertar(BE.DigitoVerificador param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@tabla", param.Tabla);
            parametros[1] = new SqlParameter("@dvv", param.DVV);
            parametros[2] = new SqlParameter("@dvh", param.DVH);
            return SqlHelper.getInstance().escribir(Tabla + "_alta", parametros);
        }

        public static int Modificar(BE.DigitoVerificador param)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@tabla", param.Tabla);
            parametros[1] = new SqlParameter("@dvv", param.DVV);
            parametros[2] = new SqlParameter("@dvh", param.DVH);
            return SqlHelper.getInstance().escribir(Tabla + "_modificar", parametros);
        }
    }
}
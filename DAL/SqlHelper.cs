using System.Data.SqlClient;
using System.Data;
using System;
using Util;

namespace DAL
{
    class SqlHelper
    {
        protected SqlConnection _conexion;
        private static SqlHelper _instancia = null;
        private static SqlHelper _instanciaBitacora = null;

        public static SqlHelper getInstance()
        {
            if (_instancia == null)
                _instancia = new SqlHelper("KineApp");
            return _instancia;
        }

        public static SqlHelper getInstanceBitacora()
        {
            if (_instanciaBitacora == null)
                _instanciaBitacora = new SqlHelper("KineAppBitacora");
            return _instanciaBitacora;
        }

        private SqlHelper(string db)
        {
            _conexion = new SqlConnection("INITIAL CATALOG = " + db + "; DATA SOURCE =.\\SQLEXPRESS; INTEGRATED SECURITY = SSPI");
        }

        public void abrir()
        {
            try
            {
                _conexion.Open();

            }
            catch (SqlException e)
            {
                Log.Error("Error al abrir " + e.ToString());
            }
        }

        public void cerrar()
        {
            try
            {
                _conexion.Close();
            }
            catch (SqlException e)
            {
                Log.Error("Error al cerrar " + e.ToString());
            }
        }

        public DataTable leer(string nombre, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            try
            {
                abrir();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(nombre, _conexion);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parametros);
                }
                adapter.Fill(tabla);
                cerrar();
            }
            catch (System.Exception e)
            {
                Log.Error("Error al Leer " + e.ToString());
            }
            return tabla;
        }

        public int escribir(string nombre, SqlParameter[] parametros)
        {
            int filas = 0;
            try
            {
                abrir();
                SqlCommand cmd = new SqlCommand(nombre, _conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }
                filas = cmd.ExecuteNonQuery();
                cerrar();
            }
            catch (System.Exception e)
            {
                Log.Error("Error al Escribir " + e.ToString());
            }
            return filas;
        }
    }
}

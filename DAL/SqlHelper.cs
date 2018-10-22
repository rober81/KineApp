using System.Data.SqlClient;
using System.Data;
using System;
using Util;

namespace DAL
{
    public class SqlHelper
    {
        protected SqlConnection _conexion;
        private static SqlHelper _instancia = null;
        private static SqlHelper _instanciaBitacora = null;
        private static Configuracion _config = null;

        public static SqlHelper getInstance()
        {
            if (_instancia == null)
            {
                _config = IoHelper.LeerConfiguracion();
                _instancia = new SqlHelper(_config.aplicacionDB);
            }
            return _instancia;
        }

        public static SqlHelper getInstanceBitacora()
        {
            if (_instanciaBitacora == null)
            {
             _config = IoHelper.LeerConfiguracion();
             _instanciaBitacora = new SqlHelper(_config.bitacoraDB);
            }
            return _instanciaBitacora;
        }

        private SqlHelper(string db)
        {
            _conexion = new SqlConnection("INITIAL CATALOG = " + db + "; DATA SOURCE =.\\" + _config.servidor + "; INTEGRATED SECURITY = SSPI");
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
                throw;
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
                throw;
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

        public int ejecutarSQL(string nombre, SqlParameter[] parametros)
        {
            int filas = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(nombre, _conexion);
                cmd.CommandType = CommandType.Text;
                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }
                filas = cmd.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                Log.Error("Error al Escribir " + e.ToString());
            }
            return filas;
        }
    }
}

using System.Data.SqlClient;
using System.Data;

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
            _conexion.Open();
        }

        public void cerrar()
        {
            _conexion.Close();
        }

        public DataTable leer(string nombre, SqlParameter[] parametros)
        {
            abrir();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tabla = new DataTable();
            adapter.SelectCommand = new SqlCommand(nombre, _conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parametros != null) {
                adapter.SelectCommand.Parameters.AddRange(parametros);
            }
            adapter.Fill(tabla);
            cerrar();
            return tabla;
        }

        public int escribir(string nombre, SqlParameter[] parametros)
        {
            abrir();
            SqlCommand cmd = new SqlCommand(nombre, _conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros);
            }
            int filas = cmd.ExecuteNonQuery();
            cerrar();
            return filas;
        }
    }
}

using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UsuarioMapper
    {
        public static BE.Usuario Login(BE.Usuario unUsuario)
        {
            BE.Usuario obj = null;
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@usuario", unUsuario.Login);
            parametros[1] = new SqlParameter("@pass", unUsuario.Password);
            DataTable tabla = SqlHelper.getInstance().leer("usuario_login", parametros);
            foreach (DataRow item in tabla.Rows) {
                obj = new BE.Usuario();
                obj.Login = item["usuario"].ToString();
                obj.Password = item["password"].ToString();
                obj.Nombre = item["nombre"].ToString();
                obj.Apellido = item["apellido"].ToString();
                obj.Correo = item["correo"].ToString();
                obj.Edad = int.Parse(item["edad"].ToString());
                obj.Dni = int.Parse(item["dni"].ToString());
            }
            return obj;
        }
    }
}
using BE;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class GestionarRolesPerfiles
    {
        public List<iPermisos> arbol { get; set; }
        List<Perfiles> lista = PerfilMapper.ListarPerfiles();

        public GestionarRolesPerfiles()
        {
            arbol = new List<iPermisos>();
            armarArbol();
        }

        private void armarArbol()
        {
            foreach (Perfiles item in lista)
            {
                if (item.Padre == 0)
                {
                    Rol rol = new Rol();
                    rol.Id = item.Id;
                    rol.Nombre = item.Nombre;
                    arbol.Add(rol);
                    Buscar(rol);
                }
            }
        }

        private void Buscar(Rol punto)
        {
            foreach (Perfiles item in lista)
            {
                if (item.Padre == punto.Id)
                {
                    Perfil perfil = new Perfil();
                    perfil.Id = item.Id;
                    perfil.Nombre = item.Nombre;
                    punto.Add(perfil);
                }

            }
        }

        public List<Perfiles> ListarPerfiles()
        {
            var filtro = from item in lista
                         where item.Padre == 0
                         select item;
            return filtro.ToList<Perfiles>();
        }

        public List<iPermisos> ListarUsuarioPerfil(Usuario param)
        {
            List<Perfiles> lista = PerfilMapper.ListarUsuarioPerfil(param);
            List<iPermisos> permisosDelUsuario = new List<iPermisos>();
            foreach (Perfiles item in lista)
            {
                foreach (iPermisos item2 in arbol)
                {
                    if (item.Id == item2.Id)
                        permisosDelUsuario.Add(item2);
                }
            }
            return permisosDelUsuario;
        }

        public int InsertarUsuarioPerfil(Usuario param, List<iPermisos> perfiles)
        {
            PerfilMapper.BorrarUsuarioPerfil(param);
            int res = 0;
            foreach ( var item in perfiles)
            {
                res += PerfilMapper.InsertarUsuarioPerfil(param, item);
            }
            Bitacora("Insertar", param);
            return res;
        }

        private void Bitacora(string accion, Usuario param)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Accion = accion;
            bitacora.Tabla = "UsuarioPerfil";
            bitacora.Dato = param.ToString();
            BLL.GestionarBitacora.Insertar(bitacora);
        }
    }
}
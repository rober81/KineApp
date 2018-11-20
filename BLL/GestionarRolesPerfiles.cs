using BE;
using DAL;
using System.Collections.Generic;

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

        public List<iPermisos> ListarUsuarioPerfil(Usuario param)
        {
            armarArbol();
            List<Perfiles> lista = PerfilMapper.ListarUsuarioPerfil(param);
            List<iPermisos> permisosDelUsuario = new List<iPermisos>();
            foreach (iPermisos item in arbol)
            {
                foreach (Perfiles item2 in lista)
                {
                    if (item.Id == item2.Id)
                        permisosDelUsuario.Add(item);
                }
            }
            return permisosDelUsuario;
        }

        public int InsertarUsuarioPerfil(Usuario param, Perfiles perfil)
        {
            return PerfilMapper.InsertarUsuarioPerfil(param, perfil);
        }

        public int BorrarUsuarioPerfil(Usuario param, Perfiles perfil)
        {
            return PerfilMapper.BorrarUsuarioPerfil(param, perfil);
        }
    }
}
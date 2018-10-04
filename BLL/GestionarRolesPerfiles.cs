using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GestionarRolesPerfiles
    {
        List<BE.iPermisos> arbol = new List<BE.iPermisos>();
        List<BE.Perfiles> lista = DAL.PerfilMapper.ListarPerfiles();

        private void armarArbol()
        {
            foreach (BE.Perfiles item in lista)
            {
                if (item.Padre == 0)
                {
                    BE.Rol rol = new BE.Rol();
                    rol.Id = item.Id;
                    rol.Nombre = item.Nombre;
                    arbol.Add(rol);
                    Buscar(rol);
                }
            }
        }

        private void Buscar(BE.Rol punto)
        {
            foreach (BE.Perfiles item in lista)
            {
                if (item.Padre == punto.Id)
                {
                    BE.Perfil perfil = new BE.Perfil();
                    perfil.Id = item.Id;
                    perfil.Nombre = item.Nombre;
                    punto.Add(perfil);
                }

            }
        }

        public List<BE.iPermisos> ListarUsuarioPerfil(BE.Usuario param)
        {
            armarArbol();
            List<int> lista = DAL.PerfilMapper.ListarUsuarioPerfil(param);
            List<BE.iPermisos> permisosDelUsuario = new List<BE.iPermisos>();
            foreach (BE.iPermisos item in arbol)
            {
                if (lista.Contains(item.Id))
                {
                    permisosDelUsuario.Add(item);
                }
            }
            return permisosDelUsuario;
        }
    }
}
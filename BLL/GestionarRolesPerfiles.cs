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

        public void armarArbol()
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

        private void Buscar(BE.iPermisos punto)
        {
            foreach (BE.Perfiles item in lista)
            {
                if (item.Padre == punto.Id)
                {
                    //punto.Add(rol);
                }

            }
        }
    }
}
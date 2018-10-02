using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Rol : iPermisos
    {
        private List<iPermisos> hijos = new List<iPermisos>();
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Add(iPermisos param)
        {
            hijos.Add(param);
        }
        public void Remove(iPermisos param)
        {
            hijos.Remove(param);
        }
        public bool VerificarPermiso()
        {
            throw new NotImplementedException();
        }
    }
}
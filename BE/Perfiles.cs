using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Perfiles : iPermisos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Padre { get; set; }

        public override string ToString()
        {
            return Id + " - " + Nombre;
        }

        public override bool Equals(object obj)
        {
            var cmp = obj as Perfiles;
            if (cmp == null)
                return false;
            else
            return Id.Equals(cmp.Id);
        }

        public List<iPermisos> Hijos
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
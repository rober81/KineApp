using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public interface iPermisos
    {
        Boolean VerificarPermiso();
        int Id { get; set; }
        string Nombre { get; set; }
    }
}
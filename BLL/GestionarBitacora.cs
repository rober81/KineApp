using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionarBitacora
    {
        public static List<BE.Bitacora> Listar()
        {
            return DAL.BitacoraMapper.Listar();
        }
        public static void Insertar(BE.Bitacora bitacora)
        {
            int filas = DAL.BitacoraMapper.Insertar(bitacora);
            if (filas == 0)
            {
                GestionarError.loguear("Error al guardar la Bitacora");
            }
        }
    }
}

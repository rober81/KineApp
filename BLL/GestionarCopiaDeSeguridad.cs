using System.Collections.Generic;

namespace BLL
{
    public class GestionarCopiaDeSeguridad
    {
        public static List<BE.CopiaDeSeguridad> Listar()
        {
            return DAL.CopiaSeguridadMapper.Listar();
        }

        public static int Backup(BE.CopiaDeSeguridad copia)
        {
            int resultado1 = DAL.CopiaSeguridadMapper.Backup(copia);
            int resultado2 = DAL.CopiaSeguridadMapper.Insertar(copia);
            return resultado1 + resultado2;
        }

        public static int Restaurar(BE.CopiaDeSeguridad copia)
        {
            int resultado1 = DAL.CopiaSeguridadMapper.Restaurar(copia);
            return resultado1;
        }

    }
}

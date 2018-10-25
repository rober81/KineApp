using BEFuncional;
using DALFuncional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLFuncional
{
    public class GestionarEjercicio
    {
        public List<Ejercicio> Listar()
        {
            return EjercicioMapper.Listar();
        }

        public static int Insertar(Ejercicio param)
        {
            return EjercicioMapper.Insertar(param);
        }

        public static int Modificar(Ejercicio param)
        {
            return EjercicioMapper.Modificar(param);
        }
    }
}

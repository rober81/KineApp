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
        List<Ejercicio> lista;
        public GestionarEjercicio()
        {
            lista = Listar();
        }

        public List<Ejercicio> Listar()
        {
            return EjercicioMapper.Listar();
        }

        public List<Ejercicio> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in Listar()
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Ejercicio>();
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

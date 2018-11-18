using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

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
            lista = EjercicioMapper.Listar();
            return lista;
        }

        public List<Ejercicio> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
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

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

        public Ejercicio Buscar(Ejercicio param)
        {
            return EjercicioMapper.Buscar(param);
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
            int res = EjercicioMapper.Insertar(param);
            Bitacora("Insertar", param);
            return res;
        }

        public static int Modificar(Ejercicio param)
        {
            int res = EjercicioMapper.Modificar(param);
            Bitacora("Modificar", param);
            return res;
        }

        private static void Bitacora(string accion, Ejercicio param)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Accion = accion;
            bitacora.Tabla = "Ejercicio";
            bitacora.Dato = param.ToString();
            BLL.GestionarBitacora.Insertar(bitacora);
        }
    }
}

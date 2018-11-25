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

        public Ejercicio Buscar(Ejercicio param)
        {
            return EjercicioMapper.Buscar(param);
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
                         item.PalabrasClave.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Ejercicio>();
        }

        public List<Ejercicio> Filtrar(string palabrasClave)
        {
            lista = EjercicioMapper.Listar();
            List<string> palabras = palabrasClave.Split(',').Select(p => p.Trim()).ToList();
            palabras.Remove("");
            palabras.Remove(" ");
            List<Ejercicio> subLista = new List<Ejercicio>();
            List<string> palabrasItem;
            foreach (var item in lista)
            {
                palabrasItem = new List<string>(item.PalabrasClave.Split(',').Select(p => p.Trim()).ToList());
                foreach (string palabra in palabras)
                {
                    if (palabrasItem.Contains(palabra) && (!subLista.Contains(item)))
                        subLista.Add(item);
                }
            }
            return subLista;
        }

        public List<Ejercicio> Filtrar(string busqueda, string palabrasClave)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in Filtrar(palabrasClave)
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

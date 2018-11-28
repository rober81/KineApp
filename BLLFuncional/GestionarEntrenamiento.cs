using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

namespace BLLFuncional
{
    public class GestionarEntrenamiento
    {
        List<Entrenamiento> lista;
        DatoBaseMapper<Entrenamiento> mapper;

        public GestionarEntrenamiento()
        {
            mapper = new DatoBaseMapper<Entrenamiento>("Entrenamiento");
            lista = Listar();
        }

        public Entrenamiento Buscar(Entrenamiento param)
        {
            Entrenamiento resultado = mapper.Buscar(param);
            resultado.ListaEjercicios = EjercicioMapper.BuscarEjercicio(param);
            return resultado;
        }

        public List<Entrenamiento> Listar()
        {
            lista = mapper.Listar();
            foreach (Entrenamiento item in lista)
            {
                item.ListaEjercicios = EjercicioMapper.BuscarEjercicio(item);
            }
            return lista;
        }

        public List<Entrenamiento> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.PalabrasClave.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Entrenamiento>();
        }

        public List<Entrenamiento> Filtrar(string palabrasClave)
        {
            lista = mapper.Listar();
            List<string> palabras = palabrasClave.Split(',').Select(p => p.Trim().ToLower()).ToList();
            palabras.Remove("");
            palabras.Remove(" ");
            List<Entrenamiento> subLista = new List<Entrenamiento>();
            List<string> palabrasItem;
            foreach (var item in lista)
            {
                palabrasItem = new List<string>(item.PalabrasClave.Split(',').Select(p => p.Trim().ToLower()).ToList());
                foreach (string palabra in palabras)
                {
                    if (palabrasItem.Contains(palabra) && (!subLista.Contains(item)))
                        subLista.Add(item);
                }
            }
            return subLista;
        }

        public List<Entrenamiento> Filtrar(string busqueda, string palabrasClave)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in Filtrar(palabrasClave)
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Entrenamiento>();
        }

        public int Insertar(Entrenamiento param)
        {
            param.Id = mapper.Insertar(param);
            foreach(Ejercicio item in param.ListaEjercicios)
            {
                EjercicioMapper.InsertarEjercicio(param, item);
            }
            Bitacora("Insertar", param);
            return param.Id;
        }

        public int Modificar(Entrenamiento param)
        {
            EjercicioMapper.BorrarEjercicio(param);
            foreach (Ejercicio item in param.ListaEjercicios)
            {
                EjercicioMapper.InsertarEjercicio(param, item);
            }
            int res = mapper.Modificar(param);
            Bitacora("Modificar", param);
            return res;
        }

        private void Bitacora(string accion, DatoBase param)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Accion = accion;
            bitacora.Tabla = "Entrenamiento";
            bitacora.Dato = param.ToString();
            BLL.GestionarBitacora.Insertar(bitacora);
        }
    }
}

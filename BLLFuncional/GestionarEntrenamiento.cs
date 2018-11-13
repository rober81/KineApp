using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

namespace BLLFuncional
{
    public class GestionarEntrenamiento
    {
        List<Entrenamiento> lista;
        public GestionarEntrenamiento()
        {
            lista = Listar();
        }

        public List<Entrenamiento> Listar()
        {
            List<Entrenamiento> lista = EntrenamientoMapper.Listar();
            foreach (Entrenamiento item in lista)
            {
                item.ListaEjercicios = EjercicioMapper.BuscarEjercicio(item);
            }
            return lista;
        }

        public Entrenamiento Buscar(Entrenamiento param)
        {
            Entrenamiento resultado = EntrenamientoMapper.Buscar(param);
            resultado.ListaEjercicios = EjercicioMapper.BuscarEjercicio(param);
            return resultado;
        }

        public List<Entrenamiento> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in Listar()
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Entrenamiento>();
        }

        public static int Insertar(Entrenamiento param)
        {
            param.Id = EntrenamientoMapper.Insertar(param);
            foreach(Ejercicio item in param.ListaEjercicios)
            {
                EjercicioMapper.InsertarEjercicio(param, item);
            }
            return param.Id;
        }

        public static int Modificar(Entrenamiento param)
        {
            EjercicioMapper.BorrarEjercicio(param);
            foreach (Ejercicio item in param.ListaEjercicios)
            {
                EjercicioMapper.InsertarEjercicio(param, item);
            }
            return EntrenamientoMapper.Modificar(param);
        }
    }
}

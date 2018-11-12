using BEFuncional;
using DALFuncional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return EntrenamientoMapper.Listar();
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
                EntrenamientoMapper.InsertarEjercicio(param, item);
            }
            return param.Id;
        }

        public static int Modificar(Entrenamiento param)
        {
            EntrenamientoMapper.BorrarEjercicio(param);
            foreach (Ejercicio item in param.ListaEjercicios)
            {
                EntrenamientoMapper.InsertarEjercicio(param, item);
            }
            return EntrenamientoMapper.Modificar(param);
        }
    }
}

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
                         item.Descripcion.ToLower().Contains(bus)
                         select item;
            return filtro.ToList<Entrenamiento>();
        }

        public static int Insertar(Entrenamiento param)
        {
            int id =  EntrenamientoMapper.Insertar(param);
            foreach(Ejercicio item in param.ListaEjercicios)
            {
                EntrenamientoMapper.InsertarEjercicio(id, item);
            }
            return 0;
        }

        public static int Modificar(Entrenamiento param)
        {
            EntrenamientoMapper.BorrarEjercicio(param);
            foreach (Ejercicio item in param.ListaEjercicios)
            {
                EntrenamientoMapper.InsertarEjercicio(param.Id, item);
            }
            return EntrenamientoMapper.Modificar(param);
        }
    }
}

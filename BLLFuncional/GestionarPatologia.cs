using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

namespace BLLFuncional
{
    public class GestionarPatologia
    {
        List<Patologia> lista;
        DatoBaseMapper<Patologia> mapper;

        public GestionarPatologia()
        {
            mapper = new DatoBaseMapper<Patologia>("Patologia");
            lista = Listar();
        }

        public List<Patologia> Listar()
        {
            lista = mapper.Listar();
            return lista;
        }

        public Patologia Buscar(Patologia param)
        {
            return mapper.Buscar(param);
        }

        public List<Patologia> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Patologia>();
        }

        public int Insertar(Patologia param)
        {
            return mapper.Insertar(param);
        }

        public int Modificar(Patologia param)
        {
            return mapper.Modificar(param);
        }
    }
}

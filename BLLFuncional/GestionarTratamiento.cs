using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

namespace BLLFuncional
{
    public class GestionarTratamiento
    {
        List<Tratamiento> lista;
        DatoBaseMapper<Tratamiento> mapper;

        public GestionarTratamiento()
        {
            mapper = new DatoBaseMapper<Tratamiento>("Tratamiento");
            lista = Listar();
        }

        public List<Tratamiento> Listar()
        {
            lista = mapper.Listar();
            return lista;
        }

        public Tratamiento Buscar(Tratamiento param)
        {
            return mapper.Buscar(param);
        }

        public List<Tratamiento> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Tratamiento>();
        }

        public int Insertar(Tratamiento param)
        {
            int res = mapper.Insertar(param);
            Bitacora("Insertar", param);
            return res;
        }

        public int Modificar(Tratamiento param)
        {
            int res = mapper.Modificar(param);
            Bitacora("Modificar", param);
            return res;
        }

        private void Bitacora(string accion, DatoBase param)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Accion = accion;
            bitacora.Tabla = "Tratamiento";
            bitacora.Dato = param.ToString();
            BLL.GestionarBitacora.Insertar(bitacora);
        }
    }
}

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

        public Tratamiento Buscar(Tratamiento param)
        {
            return mapper.Buscar(param);
        }

        public List<Tratamiento> Listar()
        {
            lista = mapper.Listar();
            return lista;
        }

        public List<Tratamiento> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Descripcion.ToLower().Contains(bus) ||
                         item.PalabrasClave.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Tratamiento>();
        }

        public List<Tratamiento> Filtrar(string palabrasClave)
        {
            lista = mapper.Listar();
            List<string> palabras = palabrasClave.Split(',').Select(p => p.Trim().ToLower()).ToList();
            palabras.Remove("");
            palabras.Remove(" ");
            List<Tratamiento> subLista = new List<Tratamiento>();
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

        public List<Tratamiento> Filtrar(string busqueda, string palabrasClave)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in Filtrar(palabrasClave)
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

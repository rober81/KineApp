using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;

namespace BLLFuncional
{
    public class GestionarConsulta
    {
        private List<Consulta> lista;

        public List<Consulta> Listar()
        {
            lista = ConsultaMapper.Listar();
            foreach (var item in lista)
            {
                item.Paciente = GestionarPaciente.Buscar(item.Paciente);
            }
            return lista;
        }

        public Consulta Buscar(Consulta param)
        {
            Consulta resultado = ConsultaMapper.Buscar(param.Id);
            resultado.Paciente = GestionarPaciente.Buscar(resultado.Paciente);
            resultado.Detalle = ConsultaMapper.BuscarDetalle(param);
            return resultado;
        }

        public List<Consulta> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Paciente.Nombre.ToLower().Contains(bus) ||
                         item.Paciente.Apellido.ToLower().Contains(bus) ||
                         item.Paciente.Dni.ToString().ToLower().Contains(bus) ||
                         item.Resumen.ToLower().Contains(bus) ||
                         item.Id.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Consulta>();
        }

        public int Insertar(Consulta param)
        {
            param.Id = ConsultaMapper.Insertar(param);
            foreach (ConsultaDetalle item in param.Detalle)
            {
                ConsultaMapper.InsertarDetalle(param.Id, item);
            }
            return param.Id;
        }

        public int Modificar(Consulta param)
        {
            ConsultaMapper.BorrarDetalle(param);
            foreach (ConsultaDetalle item in param.Detalle)
            {
                ConsultaMapper.InsertarDetalle(param.Id, item);
            }
            return ConsultaMapper.Modificar(param);
        }

        public List<ConsultaDetalle> BuscarDetalle(Consulta param)
        {
            return ConsultaMapper.BuscarDetalle(param);
        }
    }
}

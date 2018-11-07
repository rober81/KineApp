using BEFuncional;
using DALFuncional;
using System.Collections.Generic;
using System.Linq;


namespace BLLFuncional
{
    public class GestionarPaciente
    {
        List<Paciente> lista;

        public GestionarPaciente()
        {
            lista = Listar();
        }

        public List<Paciente> Listar(string busqueda)
        {
            string bus = busqueda.Trim().ToLower();
            var filtro = from item in lista
                         where item.Nombre.ToLower().Contains(bus) ||
                         item.Apellido.ToLower().Contains(bus) ||
                         item.Dni.ToString().Contains(bus)
                         select item;
            return filtro.ToList<Paciente>();
        }

        public List<Paciente> Listar()
        {
            return PacienteMapper.Listar();
        }
        
        public static void Buscar(Paciente param)
        {
            PacienteMapper.Buscar(param);
        }

        public static int Insertar(Paciente param)
        {
            return PacienteMapper.Insertar(param);
        }
        public static int Modificar(Paciente param)
        {
            return PacienteMapper.Modificar(param);
        }
    }
}


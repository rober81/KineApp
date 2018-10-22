using BEFuncional;
using DALFuncional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLFuncional
{
    public class GestionarPaciente
    {
        public static List<Paciente> Listar()
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


using BEFuncional;
using DAL;
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

        public List<Paciente> Listar()
        {
            lista = PacienteMapper.Listar();
            return lista;
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
        
        public static Paciente Buscar(Paciente param)
        {
            return PacienteMapper.Buscar(param);
        }

        public int Insertar(Paciente param)
        {
            int res = PacienteMapper.Insertar(param);
            Bitacora("Inserta",param);
            CalcularDVV();
            return res;
        }
        public int Modificar(Paciente param)
        {
            int res = PacienteMapper.Modificar(param);
            Bitacora("Modifica", param);
            CalcularDVV();
            return res;
        }

        private void Bitacora (string accion,Paciente param)
        {
            BE.Bitacora bitacora = new BE.Bitacora();
            bitacora.Accion = accion;
            bitacora.Tabla = "Paciente";
            bitacora.Dato = param.ToString();
            BLL.GestionarBitacora.Insertar(bitacora);
        }

        private void CalcularDVV()
        {
            BE.DigitoVerificador digito = new BE.DigitoVerificador();
            digito.Tabla = "Paciente";
            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(Listar());
            digito.DVV = GestionarDV.CalcularDVV(lista);
            DigitoVerificadorMapper.Modificar(digito);
        }
    }
}


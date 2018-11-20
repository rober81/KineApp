using DAL;
using DALFuncional;
using System;
using System.Collections.Generic;

namespace BLLFuncional
{
    public class GestionarDV : BLL.GestionarDigitoVerificador
    {
        public string VerificarDVHLog()
        {
            string resultado = string.Empty;

            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(DAL.UsuarioMapper.Listar());
            resultado += VerificarDVHLog(lista, UsuarioMapper.Tabla);

            lista.Clear();
            lista.AddRange(PacienteMapper.Listar());
            resultado += base.VerificarDVHLog(lista, PacienteMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVHLog(lista, ConsultaMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVHLog(lista, ConsultaMapper.Tabla2);
            return resultado;
        }

        public int VerificarDVH()
        {
            int resultado = 0;

            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(DAL.UsuarioMapper.Listar());
            resultado += VerificarDVH(lista, DAL.UsuarioMapper.Tabla);

            lista.Clear();
            lista.AddRange(PacienteMapper.Listar());
            resultado += base.VerificarDVH(lista, PacienteMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVH(lista, ConsultaMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVH(lista, ConsultaMapper.Tabla2);
            return resultado;
        }

        public string VerificarDVVLog()
        {
            string resultado = Traducir("msgVerificandoDVV") + Environment.NewLine;

            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(DAL.UsuarioMapper.Listar());
            resultado += VerificarDVVLog(lista, UsuarioMapper.Tabla);

            lista.Clear();
            lista.AddRange(PacienteMapper.Listar());
            resultado += base.VerificarDVVLog(lista, PacienteMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVVLog(lista, ConsultaMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVVLog(lista, ConsultaMapper.Tabla2);
            return resultado;
        }

        public int VerificarDVV()
        {
            int resultado = 0;

            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(DAL.UsuarioMapper.Listar());
            resultado += VerificarDVV(lista, DAL.UsuarioMapper.Tabla);

            lista.Clear();
            lista.AddRange(PacienteMapper.Listar());
            resultado += base.VerificarDVV(lista, PacienteMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVV(lista, ConsultaMapper.Tabla);

            lista.Clear();
            lista.AddRange(ConsultaMapper.Listar());
            resultado += base.VerificarDVV(lista, ConsultaMapper.Tabla2);
            return resultado;
        }
    }
}

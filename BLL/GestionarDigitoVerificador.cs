using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GestionarDigitoVerificador
    {
        public static int calcularDigito(BE.iDigitoVerificador mensaje)
        {
            return Util.DigitoVerificador.CalcularDV(mensaje.getDVH());
        }

        public static string VerificarDVH()
        {
            List<BE.iDigitoVerificador> lista = new List<BE.iDigitoVerificador>();
            lista.AddRange(DAL.UsuarioMapper.Listar());
            string resultado = VerificarDVH(lista, DAL.UsuarioMapper.Tabla);
            return resultado;
        }

        private static string VerificarDVH(List<BE.iDigitoVerificador> lista, string tabla)
        {
            string resultado = Traducir("msgComprobando") + tabla + Environment.NewLine;
            int cantidad = 0;
            foreach (BE.iDigitoVerificador item in lista)
            {
                if (! calcularDigito(item).Equals(item.DVH))
                {
                    resultado += Traducir("msgErrorRegistro") + item.getID() + Environment.NewLine;
                }
                cantidad++;
            }
            resultado += Traducir("msgRegistrosComprobados") + cantidad + Environment.NewLine;
            return resultado;
        }

        public static string CalcularDVH()
        {
            string resultado = Traducir("msgComprobando") + DAL.UsuarioMapper.Tabla + Environment.NewLine;
            int cant = DAL.UsuarioMapper.CalcularDVH();
            resultado += Traducir("msgRegistrosCalculados") + cant + Environment.NewLine;
            return resultado;
        }


        public static string VerificarDVV()
        {
            string resultado = Traducir("msgVerificandoDVV") + Environment.NewLine;
            int cantidad = 0;
            List <BE.DigitoVerificador> lista = DAL.DigitoVerificadorMapper.Listar();
            foreach (BE.DigitoVerificador item in lista)
            {
                if (item.Tabla.Equals(DAL.UsuarioMapper.Tabla))
                {
                    int dvv = DAL.UsuarioMapper.CalcularDVV();
                    if (! item.DVV.Equals(dvv))
                        resultado += Traducir("msgErrorRegistro") + item.getID() + Environment.NewLine;
                    else
                        resultado += Traducir("msgRegistro") + item.getID() + " Ok" + Environment.NewLine;
                }
                cantidad++;
            }
            resultado += Traducir("msgRegistrosComprobados") + cantidad + Environment.NewLine;
            return resultado;
        }

        public static string CalcularDVV()
        {
            string resultado = Traducir("msgCalculandoDVV") + DAL.UsuarioMapper.Tabla + Environment.NewLine;
            int dvv = DAL.UsuarioMapper.CalcularDVV();
            BE.DigitoVerificador digito = new BE.DigitoVerificador();
            digito.Tabla = DAL.UsuarioMapper.Tabla;
            digito.DVV = DAL.UsuarioMapper.CalcularDVV();
            digito.DVH = calcularDigito(digito);
            DAL.DigitoVerificadorMapper.Modificar(digito);

            resultado += Traducir("msgResultado") + digito.DVV + Environment.NewLine;
            return resultado;
        }

        private static string Traducir(string texto)
        {
            return BLL.GestionarIdioma.getInstance().getTexto(texto);
        }

    }
}
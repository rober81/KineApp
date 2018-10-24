using System.Windows.Forms;

namespace GUI.Personalizado
{
    class Estilo
    {
        public static void Guardar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightGreen;
        }

        public static void Cancelar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightSalmon;
        }

        public static void Buscar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightBlue;
        }

        public static void Nuevo(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightSkyBlue;
        }
    }
}

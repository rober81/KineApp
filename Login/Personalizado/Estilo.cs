using System.Windows.Forms;

namespace GUI
{
    class Estilo
    {
        public static void Guardar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightGreen;
            boton.Size = new System.Drawing.Size(68, 32);
        }

        public static void Cancelar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightSalmon;
            boton.Size = new System.Drawing.Size(68, 32);
        }
        public static void Agregar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightGreen;
            boton.Size = new System.Drawing.Size(68, 32);
        }

        public static void Remover(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightSalmon;
            boton.Size = new System.Drawing.Size(68, 32);
        }

        public static void Buscar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightBlue;
            boton.Size = new System.Drawing.Size(68, 32);
        }

        public static void Nuevo(Button boton)
        {
            boton.BackColor = System.Drawing.Color.LightSkyBlue;
            boton.Size = new System.Drawing.Size(68, 32);
        }

        public static void Modificar(Button boton)
        {
            boton.BackColor = System.Drawing.Color.Azure;
            boton.Size = new System.Drawing.Size(68, 32);
        }
    }
}

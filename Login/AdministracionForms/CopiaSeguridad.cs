using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class CopiaSeguridad : IdiomaForm
    {
        public CopiaSeguridad()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    BE.CopiaDeSeguridad copia = (BE.CopiaDeSeguridad)listBox1.SelectedItem;
                    if (File.Exists(copia.Nombre)){
                        BLL.GestionarCopiaDeSeguridad.Restaurar(copia);
                        Mensaje("msgRestoreOk");
                        Application.Exit();
                    } else
                    {
                        Mensaje("msgErrorArchivoNoExiste", "msgError");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Error(ex.ToString());
                Mensaje("msgRestoreNo", "msgError");
            }
      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidarTextbox())
            {
                try
                {
                    BE.CopiaDeSeguridad copia = new BE.CopiaDeSeguridad();
                    copia.Nombre = textBox1.Text;
                    copia.Fecha = DateTime.Now;
                    int res = BLL.GestionarCopiaDeSeguridad.Backup(copia);
                    if (res == 0)
                    {
                        Mensaje("msgBackOk");
                        cargar();
                    } else
                    {
                        Mensaje("msgBackNo");
                    }
                }
                catch (Exception ex)
                {
                    Util.Log.Error(ex.ToString());
                    Mensaje("msgBackNo");
                }
            }
        }

        private void cargar()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = BLL.GestionarCopiaDeSeguridad.Listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string archivo = "KineAPP_DB_" + DateTime.Now.ToString("dd-MM-yyyy-hhmmss") + ".BAK";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath + "\\" + archivo;

            }
        }

        private void CopiaSeguridad_Load(object sender, EventArgs e)
        {
            cargar();
        }
    }
}

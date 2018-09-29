using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AltaPaciente : Form, BE.iCambiarIdioma
    {
        public AltaPaciente()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void actualizar()
        {
            this.Text = BLL.GestionarIdioma.getInstance().getTexto("frmAltaPaciente");
            foreach (Control item in this.Controls)
            {
                if (null != item.Tag)
                    item.Text = BLL.GestionarIdioma.getInstance().getTexto(item.Tag.ToString());
            }
        }
    }
}

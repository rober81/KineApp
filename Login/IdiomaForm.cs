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
    public partial class IdiomaForm : Form, BE.iCambiarIdioma
    {
        public IdiomaForm()
        {
            InitializeComponent();
        }

        public virtual void actualizar()
        {
            if (null != this.Tag)
                this.Text = BLL.GestionarIdioma.getInstance().getTexto(this.Tag.ToString());
            foreach (Control item in this.Controls)
            {
                if (null != item.Tag)
                    item.Text = BLL.GestionarIdioma.getInstance().getTexto(item.Tag.ToString());
            }
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            actualizar();
        }
    }
}

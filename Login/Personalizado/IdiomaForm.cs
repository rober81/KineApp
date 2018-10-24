using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

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
            if (null != this.Tag && ! string.IsNullOrWhiteSpace(this.Tag.ToString()))
                this.Text = Traducir(this.Tag.ToString());
            actualizarControles(this.Controls);
        }

        private void actualizarControles(Control.ControlCollection controles)
        {
            foreach (Control item in controles)
            {
                if (null != item.Tag && !(item is TextBox))
                    item.Text = Traducir(item.Tag.ToString());
                if (item is GroupBox)
                    actualizarControles(item.Controls);
            }
        }

        protected string Traducir(string texto)
        {
            return BLL.GestionarIdioma.getInstance().getTexto(texto);
        }

        protected void Mensaje (string texto)
        {
             MessageBox.Show(Traducir(texto));
        }

        protected void Mensaje(string texto, string titulo)
        {
            MessageBox.Show(Traducir(texto), Traducir(titulo));
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        protected virtual Boolean validarTextbox()
        {
            foreach (Control tb in this.Controls)
            {
                if (tb is TextBox && tb.CausesValidation && string.IsNullOrWhiteSpace(tb.Text))
                {
                    if (null != tb.Tag)
                        MessageBox.Show(Traducir("msgFaltaCompletar") + " " + Traducir(tb.Tag.ToString()), Traducir("msgFaltaCompletarTitulo"));
                    return false;
                }
            }
            return true;
        }
    }
}

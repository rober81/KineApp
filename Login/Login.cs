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
    public partial class Login : IdiomaForm
    {
        public Login()
        {
            BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma("Español"));
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                BLL.GestionarSesion sesion = BLL.GestionarSesion.getInstance();
                if (sesion.iniciarSesion(textBox1.Text, textBox2.Text)){
                    this.Hide();
                    Maestro form = new Maestro();
                    form.ShowDialog();
                } else
                {
                    Mensaje("errorLogin");
                }
            }
        }

        private Boolean validar()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                Mensaje("errorCompletarUser");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                Mensaje("errorCompletarPass");
                return false;
            }
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label5.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mensaje("msgEnviarPass");
            label5.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.button1;
            try
            {
                cmbIdioma.DataSource = BLL.GestionarIdioma.getInstance().Listar();
                cmbIdioma.SelectedIndex = 0;
                BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma(cmbIdioma.SelectedItem.ToString()));
                actualizar();
            }
            catch (Exception ex)
            {
                Util.Log.Error(ex.ToString());
                throw;
            }
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma(cmbIdioma.SelectedItem.ToString()));
            actualizar();
        }
    }
}

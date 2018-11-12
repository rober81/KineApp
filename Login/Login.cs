using System;
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
                if (sesion.iniciarSesion(txtUsuario.Text, txtPass.Text)){
                    this.Hide();
                    Maestro form = new Maestro();
                    form.Show();
                } else
                {
                    Mensaje("errorLogin");
                }
            }
        }

        private Boolean validar()
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("errorCompletarUser");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtPass.Text))
            {
                Mensaje("errorCompletarPass");
                return false;
            }
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Boolean visible = ! label5.Visible;
            label5.Visible = visible;
            txtCorreo.Visible = visible;
            button2.Visible = visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mensaje("msgEnviarPass");
            label5.Visible = true;
            txtCorreo.Visible = true;
            button2.Visible = true;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label4.Parent = pictureBox1;

            this.AcceptButton = this.button1;
            try
            {
                cmbIdioma.DataSource = BLL.GestionarIdioma.getInstance().Listar();
                if (cmbIdioma.Items.Count > 0)
                {
                    cmbIdioma.SelectedIndex = 0;
                    BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma(cmbIdioma.SelectedItem.ToString()));
                    actualizar();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Error("Login: " + ex.ToString());
                MessageBox.Show("Error al Conectar a la DB");
                Application.Exit();
            }
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma(cmbIdioma.SelectedItem.ToString()));
            actualizar();
        }
    }
}

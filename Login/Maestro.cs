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
    public partial class Maestro : Form
    {
        public Maestro()
        {
            InitializeComponent();

            DialogResult resultado = MessageBox.Show("Error al conectar a la base de datos, desea continuar?", 
            "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            BLL.GestionarError.loguear("Error al conectar a la base de datos.");
            if (resultado == DialogResult.Cancel)
                Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLL.GestionarSesion.getInstance().cerrarSesion();
            Application.Exit();
        }

        private void abrirFormulario(Form mdi)
        {
            mdi.MdiParent = this;
            mdi.StartPosition = FormStartPosition.CenterScreen;
            mdi.Show();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AltaPaciente());
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Historial());
        }

        private void tratamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AbmEjercicios());
        }

        private void entrenamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AbmEntrenamiento());
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new ModificarPaciente());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Usuarios());
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Roles());
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Bitacora());
        }

        private void copiaDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new CopiaSeguridad());
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Perfiles());
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Consulta());
        }

        private void Maestro_Load(object sender, EventArgs e)
        {

        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLL.GestionarSesion.getInstance().cerrarSesion();
            this.Hide();
            Login form = new Login();
            form.ShowDialog();
        }
    }
}

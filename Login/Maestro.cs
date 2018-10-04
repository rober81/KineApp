using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class Maestro : IdiomaForm
    {
        private List<BE.iCambiarIdioma> formularios = new List<BE.iCambiarIdioma>();

        public Maestro()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void agregarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AdminIdioma());
        }

        private void Maestro_Closing(object sender, EventArgs e)
        {
            BLL.GestionarSesion.getInstance().cerrarSesion();
        }

        private void gestiónDeDigitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new DigitoVerificador());
        }

        private void abrirFormulario(Form mdi)
        {
            mdi.MdiParent = this;
            mdi.StartPosition = FormStartPosition.CenterScreen;
            mdi.Show();
            BE.iCambiarIdioma formulario = mdi as BE.iCambiarIdioma;
            if (formulario != null)
                this.formularios.Add(formulario);
        }

        private void Maestro_Load(object sender, EventArgs e)
        {
            this.FormClosing += this.Maestro_Closing;
            if ("Español".Equals(BLL.GestionarIdioma.getInstance().IdiomaSeleccionado.Nombre)) {
                españolToolStripMenuItem.Checked = true;
                inglesToolStripMenuItem.Checked = false;
            } else
            {
                españolToolStripMenuItem.Checked = false;
                inglesToolStripMenuItem.Checked = true;
            }
            this.actualizar();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLL.GestionarSesion.getInstance().cerrarSesion();
            this.Hide();
            Login form = new Login();
            form.ShowDialog();
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cambiarIdioma("Español");
            españolToolStripMenuItem.Checked = true;
            inglesToolStripMenuItem.Checked = false;
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cambiarIdioma("English");
            españolToolStripMenuItem.Checked = false;
            inglesToolStripMenuItem.Checked = true;
        }

        private void cambiarIdioma(string idioma)
        {
            BLL.GestionarIdioma.getInstance().CambiarIdioma(new BE.Idioma(idioma));
            foreach (BE.iCambiarIdioma item in formularios)
            {
                item.actualizar();
            }
            this.actualizar();
        }

        public override void actualizar()
        {
            base.actualizar();
            foreach (ToolStripMenuItem menu in menuStrip1.Items)
            {
                if (null != menu.Tag)
                    menu.Text = BLL.GestionarIdioma.getInstance().getTexto(menu.Tag.ToString());
                foreach (ToolStripMenuItem item in menu.DropDownItems)
                {
                    item.Enabled = BLL.GestionarSesion.getInstance().VerificarPermisos(item.Name);
                    if (null != item.Tag)
                        item.Text = BLL.GestionarIdioma.getInstance().getTexto(item.Tag.ToString());
                }
                
            }
            cerrarSesiónToolStripMenuItem.Enabled = true;
            salirToolStripMenuItem.Enabled = true;
            españolToolStripMenuItem.Enabled = true;
            inglesToolStripMenuItem.Enabled = true;
        }
    }
}

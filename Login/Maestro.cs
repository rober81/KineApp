using BLLFuncional;
using GUI.PacienteForms;
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

        private void Maestro_Closing(object sender, EventArgs e)
        {
            BLL.GestionarSesion.getInstance().cerrarSesion();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AbmPaciente());
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Historial());
        }

        private void tratamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new ConsultarEjercicio());
        }

        private void entrenamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new ConsultarEntrenamiento());
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new ConsultarPaciente());
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
            abrirFormulario(new ConsultarConsulta());
        }

        private void agregarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new AdminIdioma());
        }

        private void gestiónDeDigitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new DigitoVerificador());
        }

        private void patologiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormulario(new ConsultarPatologia());
        }

        private void tratamientosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            abrirFormulario(new ConsultarTratamiento());
        }

        private void abrirFormulario(Form mdi)
        {
            mdi.MdiParent = this;
            mdi.StartPosition = FormStartPosition.CenterScreen;
            mdi.FormBorderStyle = FormBorderStyle.FixedDialog;
            mdi.MaximizeBox = false;
            mdi.MinimizeBox = false;
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
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimizeBox = true;

            GestionarDV gestorDigito = new GestionarDV();
            int cantidad = gestorDigito.VerificarDVH() + gestorDigito.VerificarDVV();
            if (cantidad != 0 && gestiónDeDigitoVerificadorToolStripMenuItem.Enabled == false)
            {
                DialogResult result = MessageBox.Show(Traducir("msgErrorVerificarDV") + "-" + cantidad, Traducir("msgError"), MessageBoxButtons.OK);
                if (result == DialogResult.OK && gestiónDeDigitoVerificadorToolStripMenuItem.Enabled == false)
                {
                    Application.Exit();
                }
            }
            else if (cantidad != 0 && gestiónDeDigitoVerificadorToolStripMenuItem.Enabled == true)
            {
                MessageBox.Show(Traducir("msgErrorVerificarDV2") + "-" + cantidad, Traducir("msgError"), MessageBoxButtons.OK);
                abrirFormulario(new DigitoVerificador());
            }
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

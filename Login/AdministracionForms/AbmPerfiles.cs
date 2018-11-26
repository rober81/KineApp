using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmPerfiles : IdiomaForm
    {
        private GestionarRolesPerfiles gestor;
        private Perfiles perfilSeleccionado;

        public AbmPerfiles()
        {
            InitializeComponent();
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            gestor = new GestionarRolesPerfiles();
            Estilo.Guardar(btnCrearGrupo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Nuevo(btnNuevo);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            Actualizar();
            nuevo();
        }

        private void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.ListarPerfiles();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 150;
            cmbPadre.DataSource = null;
            cmbPadre.DataSource = gestor.ListarPerfilesPadres();
            cmbItem.DataSource = null;
            cmbItem.DataSource = gestor.ListarPermisos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int respuesta;
            try
            {
                Perfiles obj = new Perfiles();
                obj.Nombre = cmbItem.SelectedItem.ToString();
                Perfiles padre = cmbPadre.SelectedItem as Perfiles;
                if (padre == null)
                    obj.Padre = new Perfiles() { Id = 0 };
                else
                    obj.Padre = padre;

                respuesta = gestor.Insertar(obj);

                if (respuesta == 0)
                    Mensaje("msgErrorAlta", "msgError");
                else
                {
                    Mensaje("msgOperacionOk");
                    Actualizar();
                }                    
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                perfilSeleccionado = row.DataBoundItem as Perfiles;
                txtNombre.Text = perfilSeleccionado.Nombre;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void nuevo()
        {
            txtNombre.Text = string.Empty;
            lblID.Text = string.Empty;
            perfilSeleccionado = null;
            dataGridView1.ClearSelection();
        }

        private void btnCrearGrupo_Click(object sender, EventArgs e)
        {
            int respuesta;
            try
            {
                if (this.ValidarTextbox())
                {
                    if (perfilSeleccionado == null)
                    {
                        perfilSeleccionado = new Perfiles();
                        perfilSeleccionado.Nombre = txtNombre.Text.Trim();
                        perfilSeleccionado.Padre = new Perfiles() { Id = 0 };
                        respuesta = gestor.Insertar(perfilSeleccionado);
                    } else
                    {
                        perfilSeleccionado.Nombre = txtNombre.Text.Trim();
                        respuesta = gestor.Modificar(perfilSeleccionado);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                    {
                        Mensaje("msgOperacionOk");
                        Actualizar();
                        nuevo();
                    }
                }
                else
                    this.DialogResult = DialogResult.None;
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }
    }
}
